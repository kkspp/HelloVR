using UnityEngine;
using System.Collections;

public class Lepmotionposition : MonoBehaviour {
    GameObject car;
    
    // Use this for initialization
    void Start () {
        car = GameObject.Find("Car");
       
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = car.transform.Find("Lep").position;
        Quaternion q = car.transform.Find("Lep").rotation;
        gameObject.transform.position = v;
        gameObject.transform.rotation = q;
    }
}
