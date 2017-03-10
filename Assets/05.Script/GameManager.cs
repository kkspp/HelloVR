using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager instance;//싱글톤방식 전역변수.

    public bool isRedLight = false;
    public int score = 100;
    public GameObject car;
    Rigidbody carRb;
    public bool checkOverspeed = false;
    void Awake()
    {
        instance = this;//자기자신을 주입.
    }
    void Start () {
        carRb = car.GetComponent<Rigidbody>();
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

    void PassCar()  //교차로에서 차가 지나갔을 때
    {
        if(isRedLight == true)  //빨간불인데 지나갔으면 감점
        {
            DecreaseScore(10);
        }
    }

    void DecreaseScore(int dec_score)
    {
        score = score - dec_score;
        Debug.Log("스코어 " + dec_score + "점 감점");
        
    }
    void Overspeed()
    {

        if (checkOverspeed != true)
        {
            DecreaseScore(10);
        }

    }
}
