using UnityEngine;
using System.Collections;

public class GearController : MonoBehaviour {
    GameObject gearStick;
    GameObject stick1;
    GameObject stick2;
    public bool changeGear;
	public GameObject car;
    
    void Start()
    {
        changeGear = true;
        gearStick = GameObject.Find("GearStick");
        stick1 = GameObject.Find("Stick");
        stick2 = GameObject.Find("Stick2");
        stick2.SetActive(false);
		car = GameObject.Find ("Car");
    }

    //립모션 손이 닿으면
    void OnTriggerEnter(Collider other)
    {
        // 전진기어(true)
        if (other.tag == "Hand" && changeGear == true)
        {
            Debug.Log("전진기어");
            changeGear = false;
            stick2.SetActive(true);
            stick1.SetActive(false);
			car.SendMessage ("SetGearState", 1);
        }

        // 후진기어(false)
        else if (other.tag == "Hand" && changeGear == false)
        {
            Debug.Log("후진기어");
            changeGear = true;
            stick1.SetActive(true);
            stick2.SetActive(false);
			car.SendMessage ("SetGearState", -1);
        }

        
    }
}
