using UnityEngine;
using System.Collections;

public class TurnLeftSound : MonoBehaviour {
    AudioClip Sound;
    AudioSource source;
	// Use this for initialization
	void Start () {
        source=this.GetComponent<AudioSource>();
        Sound =(AudioClip) Resources.Load("Trunleft");
	}

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            source.PlayOneShot(Sound);
        }
    }
}
