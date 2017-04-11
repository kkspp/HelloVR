using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;

public class AccelationArea : MonoBehaviour
{
    Rigidbody carRb;
    float speed;
    Car::CarController m_CarController;// CarController 내에 있는 멤버 변수들을 받아오기 위해
    public GameManager gameManager;


    void Start()
    {
        m_CarController = GameObject.Find("Car").GetComponent<Car::CarController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.currentStage = 6;

            if (GameManager.instance.currentStage != GameManager.instance.pastStage + 1
                && GameManager.instance.choiceFullCourseStage == true)
            {
                Debug.Log("currentStage" + GameManager.instance.currentStage + "past" + GameManager.instance.pastStage);
                gameManager.GetComponent<GameManager>().SendMessage("WrongPath");
            }
            else
            {
                GameManager.instance.pastStage = 6;
            }

            GameManager.instance.accelationSection = true;
            Debug.Log("가속구간 돌입");
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //speed = carRb.velocity.magnitude;//속도를 벡터값으로 변환
            Debug.Log(m_CarController.CurrentSpeed);
            if (m_CarController.CurrentSpeed > 30)//수정예정
            {
                //일정속도이상 됐으니 성공
                GameManager.instance.passAccelationStage = true;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("가속구간이 지남.");
            GameManager.instance.accelationSection = false;
        }
    }

}

