using UnityEngine;
using System.Collections;

public class ChangeSignal : MonoBehaviour {
    
    public GameObject[] signal;
    public int temp_time = 0;
    RaycastHit hit;
    bool waitSignal;
    
    void Start () {
        //신호 초기화
        signal[0].GetComponent<Renderer>().material.color = Color.gray;
        signal[1].GetComponent<Renderer>().material.color = Color.gray;
        signal[2].GetComponent<Renderer>().material.color = Color.green;
        signal[3].GetComponent<Renderer>().material.color = Color.green;
        waitSignal = false;
    }
	
    void ChangeSignals()
    {
        if (waitSignal == true) //노란불
        {
            signal[0].GetComponent<Renderer>().material.color = Color.gray;
            signal[1].GetComponent<Renderer>().material.color = Color.yellow;
            signal[2].GetComponent<Renderer>().material.color = Color.gray;
            signal[3].GetComponent<Renderer>().material.color = Color.gray;

            StartCoroutine(delayTime());    //약간의 시간 딜레이 주고

            if (temp_time >= 5) //빨간불
            {
                signal[0].GetComponent<Renderer>().material.color = Color.red;
                signal[1].GetComponent<Renderer>().material.color = Color.gray;
                signal[2].GetComponent<Renderer>().material.color = Color.gray;
                signal[3].GetComponent<Renderer>().material.color = Color.gray;
                GameObject.Find("GameManager").SendMessage("RedLight");
            }

            if (temp_time >= 500)   //일정 시간 이후에 초록불
            {
                signal[0].GetComponent<Renderer>().material.color = Color.gray;
                signal[1].GetComponent<Renderer>().material.color = Color.gray;
                signal[2].GetComponent<Renderer>().material.color = Color.green;
                signal[3].GetComponent<Renderer>().material.color = Color.green;
                waitSignal = false;
                GameObject.Find("GameManager").SendMessage("GreenLight");

            }
        }
        else
        {
            temp_time = 0;
        }
    }

    
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            waitSignal = true;
            ChangeSignals();
        }
    }
    

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(1);
        temp_time++;
    }
}
