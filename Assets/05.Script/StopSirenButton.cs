using UnityEngine;
using System.Collections;


namespace Emergency
{
    public class StopSirenButton : MonoBehaviour
    {
        public bool emergencyLightOn;
        public GameObject sirenStopButtonLight;

        void Start()
        {
            emergencyLightOn = false;
            sirenStopButtonLight.SetActive(false);
        }

        void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (emergencyLightOn == false)
                {
                    Debug.Log("비상등 켜기");
                    emergencyLightOn = true;
                    sirenStopButtonLight.SetActive(true);
                }
                else if (emergencyLightOn == true)
                {
                    Debug.Log("비상등 끄기");
                    emergencyLightOn = false;
                    sirenStopButtonLight.SetActive(false);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Hand" && emergencyLightOn == false)
            {
                Debug.Log("비상등 켜기");
                emergencyLightOn = true;
                sirenStopButtonLight.SetActive(true);
            }
            else if (other.tag == "Hand" && emergencyLightOn == true)
            {
                Debug.Log("비상등 끄기");
                emergencyLightOn = false;
                sirenStopButtonLight.SetActive(false);
            }
        }
    }
}
