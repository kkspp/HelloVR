using UnityEngine;
using System.Collections;

public class YellowLineContact : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
       if(other.name== "ColliderBottom") { 
            Debug.Log("중앙선 침범");
            GameObject.Find("GameManager").SendMessage("YellowLineCheck");
        }
    }
}
