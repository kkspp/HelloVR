using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;//싱글톤방식 전역변수.
    public bool isRedLight = false;
    public int score = 100;
    public GameObject car;
    //Rigidbody carRb;
    public bool checkOverspeed = false;

    void Awake()
    {
        instance = this;//자기자신을 주입.
    }
    void Start () {
        //carRb = car.GetComponent<Rigidbody>();
	}
	
	void Update () {
        
	}

    void RedLight()
    {
        isRedLight = true;
    }

    void GreenLight()
    {
        isRedLight = false;
    }

    void PassCar()  //교차로에서 차가 지나갔을 때 미션 완료 확인
    {
        if(isRedLight == true)  //빨간불인데 지나갔으면 감점
        {
            DecreaseScore(10);
        }
    }

    void DecreaseScore(int dec_score) //스코어 감점
    {
        score = score - dec_score;
        Debug.Log("스코어 " + dec_score + "점 감점");
        
    }

    void EndAccelationArea() //가속구간 지나갔을 때 미션 완료 확인
    {
        if (checkOverspeed == false) //가속 안했으면 감점
        {
            DecreaseScore(10);
        }
        else //재시도 버그 방지를 위한 초기화
        {
            checkOverspeed = false;
        }
    }

	void UphillFail() {
		DecreaseScore (10);
	}
}
