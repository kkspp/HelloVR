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

    IEnumerator light()//빤짝빤짝거리게하는함수.
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
    void OnDisable()//스크립트가 비활성화되면 모든코루틴을꺼줌.
    {
        col.color = Color.white;
        halo.enabled = false;
        StopAllCoroutines();//코루틴함수는 비활성화해도 계속살아있기때문에 이렇게중지해야함
        StopCoroutine(light());
    }
}
