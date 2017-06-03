using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class ExitStageController : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(GameManager.instance.score >= 80)
            {
                
                GameMenus.resultText = "장내기능시험 합격입니다.";
                GameManager.instance.SuccessSound = true;
                GameMenus.isPlayerSelectingMenus = true;
                GameManager.instance.userdata.setEnd();
                UserdataObject.instance.userdata = GameManager.instance.userdata;
                SceneManager.LoadScene("MenusWhenPlayerFails");
            }
            else
            {
                GameMenus.resultText = "장내기능시험 불합격입니다.";
                GameManager.instance.SuccessSound = false;
                GameMenus.isPlayerSelectingMenus = true;
                GameManager.instance.userdata.setEnd();
                UserdataObject.instance.userdata = GameManager.instance.userdata;
                SceneManager.LoadScene("MenusWhenPlayerFails");
            }
        }
    }
}
