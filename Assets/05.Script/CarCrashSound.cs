using UnityEngine;
using System.Collections;

public class CarCrashSound : MonoBehaviour {
   public AudioSource audio;
   public AudioClip sound;
    // Use this for initialization
    void Start () {
        sound=(AudioClip)Resources.Load("Impact");
        audio =GetComponent<AudioSource>();
       //audio= transform.parent.GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
    void OnCollisionEnter(Collision other)
	{
        audio.PlayOneShot(sound);
    }
}
