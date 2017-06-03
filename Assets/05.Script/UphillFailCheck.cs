using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
    public class UphillFailCheck : MonoBehaviour {
        public UphillCheckArea UphillZone;
    
        void OnTriggerEnter(Collider other)
        { 
            if (other.tag == "Player")
            {
                GameMenus.uphill = true;
                if (GameManager.instance.isPlayerPassedUphill == true)
                {
                GameObject.FindWithTag("GameManager").SendMessage("UphillFail");
                }
            }
        }
    }
}