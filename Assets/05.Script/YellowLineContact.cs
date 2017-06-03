using UnityEngine;
using System.Collections;

public class YellowLineContact : MonoBehaviour {
    
    void OnTriggerEnter(Collider other)
    {
       if(other.name== "ColliderBottom") { 
            Debug.Log("중앙선 침범");
            GameObject.FindWithTag("GameManager").SendMessage("YellowLineText");
            GameObject.FindWithTag("GameManager").SendMessage("DecreaseScore", 15);
        }
    }
}
