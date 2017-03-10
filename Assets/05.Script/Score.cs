using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
    public int score;
	public GameObject text_score;

    // Use this for initialization
    void Start () {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score;

    }
	
	// Update is called once per frame
	void Update () {
        score = GameObject.Find("GameManager").GetComponent<GameManager>().score;
		text_score.GetComponent<TextMesh> ().text = "SCORE : "+score.ToString();
        //Debug.Log(score); 
    }
}
