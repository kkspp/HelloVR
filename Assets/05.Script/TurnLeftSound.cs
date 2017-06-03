using UnityEngine;
using System.Collections;

public class TurnLeftSound : MonoBehaviour {
    AudioClip Sound;
    AudioSource source;

	void Start () {
        source = this.GetComponent<AudioSource>();
        Sound = (AudioClip) Resources.Load("Turnleft");
	}
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            source.PlayOneShot(Sound);
        }
    }
}
