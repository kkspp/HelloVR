using UnityEngine;
using System.Collections;

public class CheckWaitforSignal : MonoBehaviour {
    public GameManager gameManager;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GameManager.instance.currentStage = 2 ;
            if (GameManager.instance.pastStage == 3)
            {
                GameManager.instance.currentStage = 4;
            }
            if(GameManager.instance.currentStage != GameManager.instance.pastStage + 1
                && GameManager.instance.choiceFullCourseStage == true)
            {
                gameManager.GetComponent<GameManager>().SendMessage("WrongPath");
            }
            else
            {
                GameManager.instance.pastStage = 2;
                if(GameManager.instance.currentStage == 4)
                {
                    GameManager.instance.pastStage = 4;
                }
            }

            GameObject.Find("GameManager").SendMessage("PassCar");
        }
    }
}
