using UnityEngine;
using System.Collections;

public class AccelationEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("가속구간 종료");
            GameObject.Find("GameManager").SendMessage("EndAccelationArea");
        }
    }
}
