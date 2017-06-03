using UnityEngine;
using System.Collections;

public class UISpinner : MonoBehaviour {
	
	void FixedUpdate () {
		transform.Rotate(Vector3.up * Time.deltaTime * 15f);
	}
}
