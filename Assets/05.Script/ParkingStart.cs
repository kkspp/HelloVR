using UnityEngine;
using System.Collections;

public class ParkingStart : MonoBehaviour {
    public GameObject gameManager;
    public ParkingManager parkingManager;

    void Start()
    {
        //parkingManager = GameObject.Find("ParkingManager").GetComponent<ParkingManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")//다시나왔을때.
        {
            if(parkingManager.ParkingSection == true)
            {
                GameManager.instance.parkingCheck = true;
                GameObject.Find("ParkingManager").SendMessage("sendGameManager");
            }
            else
            {
                Debug.Log("직진 하세요.");
                parkingManager.ParkingSection = true;
                GameManager.instance.currentStage = 3;

                if (GameManager.instance.currentStage != GameManager.instance.pastStage + 1
                    && GameManager.instance.choiceFullCourseStage == true)
                {
                    Debug.Log("currentStage" + GameManager.instance.currentStage + "past" + GameManager.instance.pastStage);
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
