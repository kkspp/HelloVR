using UnityEngine;
using System.Collections;

public class ParkingTrunRight : MonoBehaviour {
    float Times;//주차시간.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (ParkingManager.instance.BackwardCheck != true)
        {
            
                Debug.Log("경로이탈입니다");
            
        }
    }
    void OnTriggerStay(Collider other)
    {
        Times += Time.deltaTime;
        if (other.name == "ColliderBottom")
        {
            if (ParkingManager.instance.BackwardCheck == true)
            {
                if (Times > 2.0f)
                {
                    Debug.Log("우회전 후 나가세요");
                    ParkingManager.instance.TrunRightCheck = true;
                    Times = 0.0f;
                }
            }
            
        }
    }
}
