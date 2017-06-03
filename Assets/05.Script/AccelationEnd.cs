using UnityEngine;
using System.Collections;

public class AccelationEnd : MonoBehaviour {
	
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("가속구간 종료");
            GameObject.Find("GameManager").SendMessage("EndAccelationArea");
        }
    }
}
