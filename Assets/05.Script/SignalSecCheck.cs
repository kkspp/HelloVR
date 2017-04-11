using UnityEngine;
using System.Collections;

public class SignalSecCheck : MonoBehaviour {
    float Timer;
    bool Insidecheck=false;
    public GameManager gameManager;
	
	void Start () {
        Timer = 0;
	}

    // Update is called once per frame
    void Update()
    {
        if (Insidecheck == true && GameManager.instance.isGreenLight == true)//초록불이면
        {
            Timer += Time.deltaTime;

            if (Timer > 10)
            {
                GameObject.Find("GameManager").SendMessage("SignalOverWait");
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
