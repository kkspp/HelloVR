using UnityEngine;
using System.Collections;

public class AccelationArea : MonoBehaviour {

    Rigidbody carRb;
    float speed;
    //bool check = false;//구간에 차량이있는지 체크



	void Start () {
        carRb = GameObject.Find("Car").GetComponent<Rigidbody>();
	}
	
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("가속구간 돌입");          
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            speed = carRb.velocity.magnitude;//속도를 벡터값으로 변환
            if (speed > 11)//수정예정
            {   
                GameManager.instance.checkOverspeed = true;//일정속도이상 됐으니 성공
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name == "ColliderFront")
        {
            Debug.Log("가속구간이 지남.");
        }
    }

}
