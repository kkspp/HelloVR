using UnityEngine;
using System.Collections;

public class ScoreBoard : MonoBehaviour {
	public GameObject text_score;
    
    void RenewScore(int score)
    {
        text_score.GetComponent<TextMesh>().text = "SCORE : " + score.ToString();
    }
}
