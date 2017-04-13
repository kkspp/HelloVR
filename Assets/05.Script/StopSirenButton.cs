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
			if (other.tag == "Hand" && emergencyLightOn == false) {
				Debug.Log ("비상등 켜기");
				emergencyLightOn = true;
			} else if (other.tag == "Hand" && emergencyLightOn == true) {
				Debug.Log ("비상등 끄기");
				emergencyLightOn = false;
			}
    }
}
}
