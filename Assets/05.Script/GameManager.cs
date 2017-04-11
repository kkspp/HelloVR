﻿using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;
using UnityEngine.SceneManagement;
using EmergencyLight = Emergency;
public class GameManager : MonoBehaviour
{
    AudioClip sound;//띵동소리
    AudioClip Failsound;//삐익소리
    AudioClip Turnrightsound;//우회전입니다
    AudioClip Turnleftsound;//좌회전입니다
    AudioClip parkingAnnounce1; //핸들 왼쪽으로 돌려 후진하세요.
    AudioClip parkingAnnounce2; //주차성공입니다. 우회전해서 나가세요.
    AudioSource source;
    EmergencyLight::StopSirenButton m_StopSirenButton;	// StopSirenButton 내에 있는 멤버변수들을 받아오기 위해
	public CarPositionInit carPositionInit;
    public static GameManager instance;//싱글톤방식 전역변수.
    private const float MAX_SPEED_LIMIT = 20.0f;
	Car::CarController m_CarController;// CarController 내에 있는 멤버 변수들을 받아오기 위해

	public bool isRedLight;
	public bool isGreenLight;
	public int score;
    public GameObject car;
	public bool isPlayerPassedUphill;
	public bool passAccelationStage;
	public bool accelationSection;
	public bool parkingCheck;
	public bool overSpeedCheck;
	public bool accidentCheck;
    public bool SuccessSound;//성공사운드 실패사운드 선택.

    public bool choiceFullCourseStage = false;
    public ParkingManager parkingManager;

    //Stage number 구성 - 출발:0 경사로:1 교차로:2 직각주차:3 교차로:4 돌발:5 가속:6
    public int currentStage;
    public int pastStage;

    void Awake()
    {		
        instance = this;//자기자신을 주입.
		Init();
    }

    void Start()
    {

        source = GetComponent<AudioSource>();
        sound = (AudioClip)Resources.Load("Bing");
        Failsound = (AudioClip)Resources.Load("FailSound");
        Turnleftsound = (AudioClip)Resources.Load("Turnleft");
        Turnrightsound = (AudioClip)Resources.Load("Turnright");
        parkingAnnounce1 = (AudioClip)Resources.Load("ParkingAnnounce");
        parkingAnnounce2 = (AudioClip)Resources.Load("ParkingAnnounce2"); ;
        this.m_CarController = car.GetComponent<Car::CarController>();
		this.m_StopSirenButton = GameObject.Find("SirenStopButton").GetComponent<EmergencyLight::StopSirenButton>();
    }

	void Init(){
		isRedLight = false;
		isGreenLight = false;
		score = 100;
        GameObject.Find("ScoreBoard").SendMessage("RenewScore", score);//스코어 화면에 100점 나오게
        isPlayerPassedUphill = false;
        passAccelationStage = false;//가속이성공했는지.
		accelationSection = false;//가속구간인지
		parkingCheck = false;
		overSpeedCheck = false;//과속체크
		accidentCheck = false;//돌발구간 체크
        SuccessSound = false;
        choiceFullCourseStage = false;
        currentStage = 0; //현재 있는 stage 
        pastStage = 0; //전에 있었던 stage
    }

	// 사용자가 올바른 순서대로 응시하지 않을때 
	void WrongPath(){
		GameMenus.isPlayerSelectingMenus = true;
		GameMenus.resultText = "코스를 순서대로 진행해 주세요";
		SceneManager.LoadScene ("MenusWhenPlayerFails");
	}

    void Update()
    {
        if (accelationSection == false || overSpeedCheck == false)//가속구간이 아니고 과속중이아닐때
        {
            CheckOverSpeeding();
        }

        /*
	    // 만약 점수가 0점 이하로 떨어지면 
	    if (score <= 0) {

		    // 플레이어는 메뉴를 바라보고 있으며 
		    GameMenus.isPlayerSelectingMenus = true;

		    // 메뉴에 출력할 텍스트를 설정합니다.
		    GameMenus.resultText = "감점으로 인한 실격입니다!";
            SuccessSound = false;
		    // 메뉴 씬을 불러옵니다. 
			SceneManager.LoadScene ("MenusWhenPlayerFails");
		}
        */
    }

    void RedLight()
    {
        isRedLight = true;
        isGreenLight = false;
    }

    void GreenLight()
    {
        isGreenLight = true;
        isRedLight = false;
    }

    void PassCar()  //교차로에서 차가 지나갔을 때 미션 완료 확인
    {
        if (isRedLight == true)  //빨간불인데 지나갔으면 실격
        {
            GameMenus.isPlayerSelectingMenus = true;
            SuccessSound = false;
            GameMenus.resultText = "신호위반 실격입니다.";
            SceneManager.LoadScene("MenusWhenPlayerFails");
        }
    }

	void PassCarRestart(){
        playSound();
        if (!carPositionInit.isPlayerDoingWholeStage) {
            GameMenus.resultText = "합격입니다.교차로구간 연습이 종료되었습니다.";
            GameMenus.isPlayerSelectingMenus = true;
            SuccessSound = true;
            SceneManager.LoadScene ("MenusWhenPlayerFails");
		}
	}

    void DecreaseScore(int dec_score) //스코어 감점
    {
        score = score - dec_score;
        Debug.Log("스코어 " + dec_score + "점 감점");
        //스코어 텍스트화면 갱신
        GameObject.Find("ScoreBoard").SendMessage("RenewScore", score);
        playFailSound();
    }

    void EndAccelationArea() //가속구간 지나갔을 때 미션 완료 확인
    {
        if (passAccelationStage == false) //가속 안했으면 감점
        {
            DecreaseScore(10);
            if (!carPositionInit.isPlayerDoingWholeStage)
            {
                GameMenus.isPlayerSelectingMenus = true;
                SuccessSound = false;
                GameMenus.resultText = "불합격입니다.가속구간 연습이 종료되었습니다.";
                SceneManager.LoadScene("MenusWhenPlayerFails");
            }
        }
        else //재시도 버그 방지를 위한 초기화
        {
            playSound();
            passAccelationStage = false;
            if (!carPositionInit.isPlayerDoingWholeStage)
            {
                GameMenus.isPlayerSelectingMenus = true;
                SuccessSound = true;
                GameMenus.resultText = "합격입니다.가속구간 연습이 종료되었습니다.";
                SceneManager.LoadScene("MenusWhenPlayerFails");
            }
        }
		
    }

    void UphillFail()
    {
        DecreaseScore(10);
        Debug.Log("뒤로 많이 밀렸습니다");
    }

    void ParkingSuccess()
    {
        if (parkingManager.checking == true)
        {
            playSound();
            Debug.Log("주차성공 입니다");
            if (!carPositionInit.isPlayerDoingWholeStage)
            {
                SuccessSound = true;
                GameMenus.resultText = "합격입니다.직각주차 연습이 종료되었습니다.";
                GameMenus.isPlayerSelectingMenus = true;
                SceneManager.LoadScene("MenusWhenPlayerFails");
            }
        }
        else
        {
            GameMenus.isPlayerSelectingMenus = true;
            SuccessSound = false;
            GameMenus.resultText = "직각주차 실격입니다.";
            SceneManager.LoadScene("MenusWhenPlayerFails");
            Debug.Log("주차구간 실격입니다");
        }

		GameObject.Find("ParkingManager").SendMessage("ParkingReset");//변수초기화

		
    }

    void CheckOverSpeeding()
    {
        //가속구간이 아닐 때
        if(accelationSection == false)
        {
            //그 전에 과속을 안했었는데
            if(overSpeedCheck == false)
            {
                // 과속한다면?	
                if (this.m_CarController.CurrentSpeed >= MAX_SPEED_LIMIT)
                {
                    print("20km/h를 넘어서 감점");
                    DecreaseScore(10);
                    overSpeedCheck = true;
                }
            }
            //그 전에 과속을 했는데
            else
            {
                // 정상 속도로 주행한다면?
                if (this.m_CarController.CurrentSpeed <= MAX_SPEED_LIMIT)
                {
                    overSpeedCheck = false;
                }
            }
        }
    }

    void AccidentChecking()
    {
        if (m_StopSirenButton.emergencyLightOn == false && accidentCheck == true)
        {
            playSound();
            Debug.Log("돌발구간 합격입니다");
            if (!carPositionInit.isPlayerDoingWholeStage)
            {
                SuccessSound = true;
                GameMenus.resultText = "합격입니다.돌발구간 연습이 종료되었습니다.";
                GameMenus.isPlayerSelectingMenus = true;
                SceneManager.LoadScene("MenusWhenPlayerFails");
            }
        }
        else if (m_StopSirenButton.emergencyLightOn == true || accidentCheck == false)
        {
            DecreaseScore(10);
            Debug.Log("돌발구간 실패이유:비상등이 켜져있습니다.");
            if (!carPositionInit.isPlayerDoingWholeStage)
            {
                SuccessSound = false;
                GameMenus.resultText = "불합격입니다.돌발구간 연습이 종료되었습니다.";
                GameMenus.isPlayerSelectingMenus = true;
                SceneManager.LoadScene("MenusWhenPlayerFails");
            }
        }
		
    }
    void AccidentFail()
    {
        DecreaseScore(10);
        Debug.Log("돌발구간 불합격");
    }

    void SignalOverWait()
    {
        Debug.Log("출발좀 하세요");
        DecreaseScore(5);
    }

    void playSound()
    {
        //리소스파일에잇는 Bing를 로드시켜서 sound에 저장.
        source.PlayOneShot(sound);
    }

    void playFailSound()
    {
        source.PlayOneShot(Failsound);
    }
    void playTurnrightSound()
    {
        source.PlayOneShot(Turnrightsound);
    }
    void playTurnleftSound()
    {
        source.PlayOneShot(Turnleftsound);
    }
    void playParkingAnnounceSound1()
    {
        source.PlayOneShot(parkingAnnounce1);
    }
    void playParkingAnnounceSound2()
    {
        source.PlayOneShot(parkingAnnounce2);
    }
}
