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
        if (other.tag == "Player")
        {
            Debug.Log("직진 하세요.");
            ParkingManager.instance.ParkingSection = true;
        }
        if(ParkingManager.instance.checking == true)//전부다 성공하고 다시 Collider에 부딛혔을때.
        {
            GameManager.instance.ParkingCheck = true;
            GameObject.Find("ParkingManager").SendMessage("sendGameManager");
        }
    }
}
