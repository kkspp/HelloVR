using UnityEngine;
using System.Collections;
using Car = UnityStandardAssets.Vehicles.Car;
using EmergencyLight = Emergency;

public class AccidentManager : MonoBehaviour {
    Car::CarController m_CarController;	// CarController 내에 있는 멤버 변수들을 받아오기 위해
	EmergencyLight::StopSirenButton m_StopSirenButton;	// StopSirenButton 내에 있는 멤버변수들을 받아오기 위해
    public GameObject car;
	public GameObject sirenObject;
    public Siren siren;	//사이렌 script따옴~
    public AudioSource sound;	//삐용삐용소리
    float Times;	//타이머
    void Start () {
        this.m_CarController = car.GetComponent<Car::CarController>();
		this.m_StopSirenButton = sirenObject.GetComponent<EmergencyLight::StopSirenButton>();
        sound = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
      
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") { 
            siren.enabled = true;//사이렌스크립트켜서 빤짝빤짝
            sound.enabled = true;//삐용삐용소리
        }
        Debug.Log("비상등을 누르고 멈추세요");
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player") { 
			if(m_StopSirenButton.emergencyLightOn == true && m_CarController.CurrentSpeed<0.1f)//비상등을키고 브레이크를밟으면
        	{ 
        		Times += Time.deltaTime;
            	if (Times > 2.0f)
        	    {
    	        	Debug.Log("성공입니다. 비상등을 끄고 출발하세요");
	                GameManager.instance.accidentCheck = true;
					siren.enabled = false;//사이렌스크립트켜서 빤짝빤짝
					sound.enabled = false;//삐용삐용소리
					GameObject.Find("GameManager").SendMessage("AccidentChecking");
				}
        	}
        }
    }
   
}
