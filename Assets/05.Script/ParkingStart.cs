using UnityEngine;
using System.Collections;

public class ParkingStart : MonoBehaviour {
    public GameObject gameManager;
    public ParkingManager parkingManager;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")//다시나왔을때.
        {
            if(parkingManager.ParkingSection == true)
            {
                GameManager.instance.userdata.parking.setSuccess("Success");
                GameManager.instance.parkingCheck = true;
                GameObject.Find("ParkingManager").SendMessage("sendGameManager");
            }
            else
            {
                GameManager.instance.userdata.parking.setStart();//시작시간저장
                parkingManager.ParkingSection = true;
                GameManager.instance.currentStage = 3;

                if (GameManager.instance.currentStage != GameManager.instance.pastStage + 1 && GameManager.instance.choiceFullCourseStage == true)
                {
                    gameManager.GetComponent<GameManager>().SendMessage("WrongPath");
                }
                else
                {
                    GameManager.instance.pastStage = 3;
                }
            }
        }
    }
}
