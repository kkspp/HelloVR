using UnityEngine;
using System.Collections;

public class SoundSorFController : MonoBehaviour {
    public AudioClip success;
    public AudioClip fail;
    AudioSource source;
    
    void Start () {
       source= GetComponent<AudioSource>();
        if (GameManager.instance.SuccessSound == true)
        {
            source.PlayOneShot(success,1.0f);
        }
        else if(GameManager.instance.SuccessSound == false){
            source.PlayOneShot(fail, 1.0f);
        }
    }
	
}
