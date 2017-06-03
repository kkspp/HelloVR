using UnityEngine;
using System.Collections;

public class SignalSecCheck : MonoBehaviour {
    float Timer;
    bool Insidecheck;
	
	void Start () {
        Timer = 0;
        Insidecheck = false;
    }
    
    void Update()
    {
        if (Insidecheck == true && GameManager.instance.isGreenLight == true)//초록불이면
        {
            Timer += Time.deltaTime;

            if (Timer > 10)
            {
                GameObject.FindWithTag("GameManager").SendMessage("SignalOverWait");
                Timer = 0;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Insidecheck = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Insidecheck = false;
        }
    }
}
