using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;//싱글톤방식 전역변수.
    private const float MAX_SPEED_LIMIT = 20.0f;
    public bool isRedLight = false;
    public int score = 100;
    public GameObject car;
    //Rigidbody carRb;
    public bool checkAccelation = false;//가속이성공했는지.
    public bool AccelationSection = false;//가속구간인지
    public bool ParkingCheck = false;
    public bool overSpeedCheck = false;//과속체크
    public bool accidentCheck = false;//돌발구간 체크
    Car::CarController m_CarController;// CarController 내에 있는 멤버 변수들을 받아오기 위해

    int WARN_MAX_SPEED = 20;
    void Awake()
    {
        instance = this;//자기자신을 주입.
    }
    void Start()
    {
        this.m_CarController = car.GetComponent<Car::CarController>();

    }

    void Update()
    {
        if (AccelationSection == false || overSpeedCheck == false)//가속구간이 아니고 과속중이아닐때
        {
            CheckVelocity();
        }

    }

    void RedLight()
    {
        isRedLight = true;
    }

    void GreenLight()
    {
        isRedLight = false;
    }

    void PassCar()  //교차로에서 차가 지나갔을 때 미션 완료 확인
    {
        if (isRedLight == true)  //빨간불인데 지나갔으면 감점
        {
            DecreaseScore(10);
        }
    }

    void DecreaseScore(int dec_score) //스코어 감점
    {
        score = score - dec_score;
        Debug.Log("스코어 " + dec_score + "점 감점");

    }

    void EndAccelationArea() //가속구간 지나갔을 때 미션 완료 확인
    {
        if (checkAccelation == false) //가속 안했으면 감점
        {
            DecreaseScore(10);
        }
        else //재시도 버그 방지를 위한 초기화
        {
            checkAccelation = false;
        }
    }

    void UphillFail()
    {
        DecreaseScore(10);
    }

    void ParkingSuccess()
    {
        if (ParkingManager.instance.checking == true)
        {
            Debug.Log("주차성공 입니다");
        }
        else
        {
            Debug.Log("주차구간 실격입니다");
        }
		GameObject.Find("ParkingManager").SendMessage("ParkingReset");//변수초기화
    }

    void CheckVelocity()
    {
        if (AccelationSection == false && overSpeedCheck == false)//가속구간이 아니고 과속으로 점수가안떨어졌을때
        {
            if (this.m_CarController.CurrentSpeed >= MAX_SPEED_LIMIT)
            {           // 만약 최대 속력보다 크면 ?		
                Warn(WARN_MAX_SPEED);                                                   // Warn() 함수 실행 (최대 속력 경고)
            }
        }
        if (AccelationSection == false && overSpeedCheck == true)//가속구간이 아니고 과속으로 점수가떨어졌을때
        {
            if (this.m_CarController.CurrentSpeed <= MAX_SPEED_LIMIT)
            {           // 만약 최대 속력보다 크면 ?		
                overSpeedCheck = false;
            }
        }
    }

    void Warn(int WARN_CODE)
    {
        print("20km/h를 넘어서 감점");
        DecreaseScore(10);
        overSpeedCheck = true;
    }

    void AccidentChecking()
    {
        if (accidentCheck == true)
        {
            Debug.Log("돌발구간 합격입니다");
        }
        else if (accidentCheck == false)
        {
            DecreaseScore(10);
            Debug.Log("돌발구간 실패");
        }
    }
}
