using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;
using EmergencyLight = Emergency;

public class AccidentManager : MonoBehaviour
{
    Car::CarController m_CarController; // CarController 내에 있는 멤버 변수들을 받아오기 위해
    EmergencyLight::StopSirenButton m_StopSirenButton;	// StopSirenButton 내에 있는 멤버변수들을 받아오기 위해
    GameObject car;
    public GameObject sirenObject;
    public Siren siren;	//사이렌 script따옴~
    public AudioSource sound;	//삐용삐용소리
    float Times;	//타이머
    float SecondTimes;//두번쨰타이머
    public GameManager gameManager;
    

    void Start()
    {
		car = GameObject.FindWithTag ("Car");
        m_CarController = car.GetComponent<Car::CarController>();
        m_StopSirenButton = sirenObject.GetComponent<EmergencyLight::StopSirenButton>();
        sound = GetComponent<AudioSource>();

    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.userdata.unexcepted.setStart();
            GameManager.instance.userdata.unexcepted.setSuccess("Fail");
            GameManager.instance.currentStage = 5;
            if ((GameManager.instance.currentStage - GameManager.instance.pastStage != 1)
                && GameManager.instance.choiceFullCourseStage == true)
            {
                Debug.Log("currentStage" + GameManager.instance.currentStage + "past" + GameManager.instance.pastStage);
                gameManager.GetComponent<GameManager>().SendMessage("WrongPath");
            }
            else
            {
                GameManager.instance.pastStage = 5;
            }
            siren.enabled = true;//사이렌스크립트켜서 빤짝빤짝
            sound.enabled = true;//삐용삐용소리
        }
        Debug.Log("비상등을 누르고 멈추세요");
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Times += Time.deltaTime;
            if (m_CarController.CurrentSpeed < 0.2f)//브레이크를밟으면
            {
                Times = -100.0f;
                SecondTimes += Time.deltaTime;
                if (SecondTimes > 3.0f)//브레이크는 했지만 비상등을안키고 3초가지나면
                {
                    Debug.Log("비상등을 안켰습니다.");
                    GameObject.Find("GameManager").SendMessage("AccidentFail");
                    SecondTimes = 0;
                    GameManager.instance.accidentCheck = true;//다시점수안깎기위해
                }
                else if (m_StopSirenButton.emergencyLightOn == true)//비상등을키면
                {
                    SecondTimes = 0;
                    Debug.Log("성공입니다. 비상등을 끄고 출발하세요");
                    GameManager.instance.accidentCheck = true;
                    GameManager.instance.emeremergencyLightCheck = true;
                    siren.enabled = false;//사이렌스크립트켜서 빤짝빤짝
                    sound.enabled = false;//삐용삐용소리
                }
            }
            //4초동안 멈추지 않았으면 실패
            else if (Times > 4.0f)
            {
                Times = -100.0f;
                GameObject.Find("GameManager").SendMessage("AccidentStartFail");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        GameManager.instance.userdata.unexcepted.setEnd();
        siren.enabled = false;//사이렌스크립트켜서 빤짝빤짝
        sound.enabled = false;//삐용삐용소리
        if (other.tag == "Player")
        {
            GameObject.Find("GameManager").SendMessage("AccidentChecking");
        }
    }

}
