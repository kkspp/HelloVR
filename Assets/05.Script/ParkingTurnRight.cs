using UnityEngine;
using System.Collections;

using Car = UnityStandardAssets.Vehicles.Car;

public class ParkingTurnRight : MonoBehaviour
{
    float Times;//주차시간.
    Car::CarController m_CarController;// CarController 내에 있는 멤버 변수들을 받아오기 위해

    
    void OnTriggerEnter(Collider other)
    {
    	if (other.tag =="Player"&& ParkingManager.instance.BackwardCheck != true)
        {
        	Debug.Log("경로이탈입니다");
            GameObject.Find("ParkingManager").SendMessage("sendGameManager");
		}
    }

    void OnTriggerStay(Collider other)
    {
    	Times += Time.deltaTime;
        if (other.name == "ColliderBottom")
        {
        	if (ParkingManager.instance.BackwardCheck == true)
            {
            	if (Times > 1.0f /*&& 사이드브레이크*/)
                {
                	Debug.Log("우회전 후 나가세요");
                    ParkingManager.instance.TrunRightCheck = true;
                    Times = 0.0f;
                }
            }
		}
    }
}
