using UnityEngine;
using System.Collections;

public class ParkingBacrward : MonoBehaviour {

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
            Debug.Log("핸들을 왼쪽으로 돌린후 후진하세요");

            ParkingManager.instance.BackwardCheck = true;
        }
    }
}
