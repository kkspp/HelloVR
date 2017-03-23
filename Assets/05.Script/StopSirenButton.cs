using UnityEngine;
using System.Collections;


namespace Emergency {
	
public class StopSirenButton : MonoBehaviour {
	public bool emergencyLightOn;
	// Use this for initialization
	void Start () {
		emergencyLightOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hand") {
            Debug.Log("비상등 켜기");
			emergencyLightOn = true;
        }
    }
}
}
