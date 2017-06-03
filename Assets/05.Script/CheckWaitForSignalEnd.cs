using UnityEngine;
using System.Collections;

public class CheckWaitForSignalEnd : MonoBehaviour {

	private void OnTriggerExit(Collider collider){
		if (collider.gameObject.tag == "Player")
		{
			GameObject.FindWithTag("GameManager").SendMessage("PassCarRestart");
		}
	}
}
