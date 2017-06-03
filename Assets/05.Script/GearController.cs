using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;

public class GearController : MonoBehaviour
{
    Car::CarController m_CarController;
    GameObject stick1;
    GameObject stick2;
    public bool changeGear;
    public GameObject car;
    int speed; 

    void Start()
    {
        m_CarController = GameObject.FindWithTag("Car").GetComponent<Car::CarController>();
        changeGear = false;
        stick1 = GameObject.Find("Stick");
        stick2 = GameObject.Find("Stick2");
        stick2.SetActive(false);
        car = GameObject.Find("Car");
    }
    void Update()
    {
        speed = (int)m_CarController.CurrentSpeed;
    }
    public void doChangingGear()
    {
        if (Input.GetKeyDown(KeyCode.N) && speed<1 )
        {
            // 전진기어(true)
            if (changeGear == true)
            {
                Debug.Log("전진기어");
                changeGear = false;

                stick1.SetActive(true);
                stick2.SetActive(false);

                car.SendMessage("SetGearState", 1);
            }

            // 후진기어(false)
            else if (changeGear == false)
            {
                Debug.Log("후진기어");
                changeGear = true;
                stick1.SetActive(false);
                stick2.SetActive(true);
                car.SendMessage("SetGearState", -1);
            }

        }
    }
    private void FixedUpdate()
    {
        doChangingGear();
    }
    //립모션 손이 닿으면
    void OnTriggerEnter(Collider other)
    {
        if(speed<1) {
            // 전진기어(true)
            if (other.tag == "Hand" && changeGear == true)
            {
                changeGear = false;
                stick1.SetActive(true);
                stick2.SetActive(false);
                car.SendMessage("SetGearState", 1);
            }

            // 후진기어(false)
            else if (other.tag == "Hand" && changeGear == false)
            {
                changeGear = true;
                stick1.SetActive(false);
                stick2.SetActive(true);
                car.SendMessage("SetGearState", -1);
            }
        }

    }
}
