using UnityEngine;
using System.Collections;

public class ParkingManager : MonoBehaviour {
    public bool ParkingSection;//구간진입
    public bool BackwardCheck;//후진해야할곳 진입
    public bool TrunRightCheck;//우회전으로 나가야할곳 진입.주차완료확인
    public bool checking; //전체적인 성공인지아닌지체크.

    void Start()
    {
        ParkingSection = false;//구간진입
        BackwardCheck = false;//후진해야할곳 진입
        TrunRightCheck = false;//우회전으로 나가야할곳 진입.주차완료확인
        checking = false; //전체적인 성공인지아닌지체크.
    }
	void Update () {
        if (ParkingSection == true && BackwardCheck==true && TrunRightCheck==true)
        {
            checking = true;
        }
	}

    void sendGameManager()
    {
        GameObject.Find("GameManager").SendMessage("ParkingSuccess");
    }
    void ParkingReset()
    {
       ParkingSection = false;
       BackwardCheck = false;
       TrunRightCheck = false;
       checking = false;
    }
}
