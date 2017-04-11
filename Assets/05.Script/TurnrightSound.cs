using UnityEngine;
using System.Collections;

public class TurnrightSound : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.instance.SendMessage("playTurnrightSound");
        }
    }
}
