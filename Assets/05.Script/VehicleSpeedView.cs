using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;
public class VehicleSpeedView : MonoBehaviour {
    TextMesh text_speed;
    Car::CarController m_CarController;// CarController 내에 있는 멤버 변수들을 받아오기 위해
    int speed; 
    
    void Start () {
        m_CarController = GameObject.FindWithTag("Car").GetComponent<Car::CarController>();
        text_speed = gameObject.GetComponent<TextMesh>();
	}
	
	void Update () {
        speed = (int)m_CarController.CurrentSpeed;
        text_speed.text = "    "+speed.ToString() + " km/h";
  	}
}
