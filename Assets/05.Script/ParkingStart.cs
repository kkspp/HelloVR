using UnityEngine;
using System.Collections;

public class ParkingStart : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && ParkingManager.instance.ParkingSection == true)//다시나왔을때.
        {
            GameManager.instance.ParkingCheck = true;
            GameObject.Find("ParkingManager").SendMessage("sendGameManager");
        }
        if (other.tag == "Player"&& ParkingManager.instance.ParkingSection == false)
        {
            Debug.Log("직진 하세요.");
            ParkingManager.instance.ParkingSection = true;
        }
        
    }
}
