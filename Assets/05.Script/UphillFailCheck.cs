using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Vehicles.Car
{
    public class UphillFailCheck : MonoBehaviour {
       public UphillCheckArea UphillZone;
    // Use this for initialization
        void Start() {
            
        }

        // Update is called once per frame
        void Update() {
         
        }
        void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
				if (GameManager.instance.isPlayerPassedUphill == true)
                {
                    GameObject.Find("GameManager").SendMessage("UphillFail");
                }
            }
        }
    }

}