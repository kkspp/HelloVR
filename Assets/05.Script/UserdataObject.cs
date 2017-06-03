using UnityEngine;
using System.Collections;

public class UserdataObject : MonoBehaviour {
    public static UserdataObject instance;
    public Userdata userdata;
    // Use this for initialization
    void Awake()
    {
        instance = this;//자기자신을 주입.
    }
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
