using UnityEngine;
using System.Collections;

public class CheckWaitforSignal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.gameObject.name);
        if (collider.gameObject.tag == "Player")
        {
            GameObject.Find("GameManager").SendMessage("PassCar");
        }
    }
}
