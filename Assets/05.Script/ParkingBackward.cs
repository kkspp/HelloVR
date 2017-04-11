using UnityEngine;
using System.Collections;

public class ParkingBackward : MonoBehaviour {
    public ParkingManager parkingManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			GameManager.instance.SendMessage ("playParkingAnnounceSound1");
            Debug.Log("핸들을 왼쪽으로 돌린후 후진하세요");

            parkingManager.BackwardCheck = true;
        }
    }
}
