using UnityEngine;
using System.Collections;

public class ChangeSignal : MonoBehaviour {
    
    public GameObject[] signal;
    public Transform signalBox;
    public int temp_time = 0;

    RaycastHit hit;
    bool waitSignal = false;
    


    void Start () {
        //신호 초기화
        signal[0].GetComponent<Renderer>().material.color = Color.gray;
        signal[1].GetComponent<Renderer>().material.color = Color.gray;
        signal[2].GetComponent<Renderer>().material.color = Color.green;
        signal[3].GetComponent<Renderer>().material.color = Color.green;
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

	void Update () {
        //Ray를 시각적으로 표시하기 위해 사용
        Debug.DrawRay(signalBox.position, -signalBox.right * 40.0f + Vector3.down*5.0f, Color.green);

        if (Physics.Raycast(signalBox.position, -signalBox.right * 40.0f + Vector3.down * 5.0f, out hit, 40.0f))
        {
            if(hit.collider.gameObject)
            {
                waitSignal = true;
            }
        }
        ChangeSignals();
        
    }

    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(1);
        temp_time++;
    }
}
