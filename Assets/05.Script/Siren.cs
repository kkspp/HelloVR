using UnityEngine;
using System.Collections;

public class Siren : MonoBehaviour {
    Behaviour halo;
    public Material col;
    // Use this for initialization
    void Start () {
        halo = (Behaviour)GetComponent("Halo");
        StartCoroutine(light());
        col.color = Color.white;
        halo.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
       
        
	}
    IEnumerator light()
    {
        while (true) { 
        yield return new WaitForSeconds(0.3f);

        if (halo.enabled == true)
        {
            col.color = Color.white;
            halo.enabled = false;
        }
        else
        {
            col.color = Color.red;
            halo.enabled = true;
        }
        }
    }
}
