using UnityEngine;
using System.Collections;

public class DontdestoryObject : MonoBehaviour {

 
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
   
}
