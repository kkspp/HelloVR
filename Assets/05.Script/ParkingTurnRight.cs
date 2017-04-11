using UnityEngine;
using System.Collections;

using Car = UnityStandardAssets.Vehicles.Car;

public class ParkingTurnRight : MonoBehaviour
{
    public ParkingManager parkingManager;

    float Times;//주차시간.
    Car::CarController m_CarController;// CarController 내에 있는 멤버 변수들을 받아오기 위해

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Player" && parkingManager.BackwardCheck == false) {
			Debug.Log ("경로이탈입니다");
			GameObject.Find ("ParkingManager").SendMessage ("sendGameManager");
		}
		else if(other.tag == "Player" && parkingManager.BackwardCheck == true ){
            Debug.Log("우회전 후 나가세요");
            parkingManager.TrunRightCheck = true;
            GameManager.instance.SendMessage ("playParkingAnnounceSound2");
		}
    }
    /*
    void OnTriggerStay(Collider other)
    {
    	Times += Time.deltaTime;
        if (other.tag == "Player")
        {
        	if (parkingManager.BackwardCheck == true)
            {
            	if (Times > 1.0f ) //&& 사이드브레이크)
                {
                	Debug.Log("우회전 후 나가세요");
                    parkingManager.TrunRightCheck = true;
                    Times = 0.0f;
                }
            }
		}
    }
    */
}
