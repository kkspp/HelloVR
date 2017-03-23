using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;

public class AccelationArea : MonoBehaviour
    {

        Rigidbody carRb;
        float speed;
        Car::CarController m_CarController;// CarController 내에 있는 멤버 변수들을 받아오기 위해
                                       



    void Start()
        {
         this.m_CarController = GameObject.Find("Car").GetComponent<Car::CarController>();
        }

        void Update()
        {

        }
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                 GameManager.instance.AccelationSection = true;
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
                
                    GameManager.instance.checkAccelation = true;//일정속도이상 됐으니 성공
                }
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.name == "ColliderFront")
            {
                Debug.Log("가속구간이 지남.");
                GameManager.instance.AccelationSection = false;
            }
        }

    }

