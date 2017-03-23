using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubmitStudentNumber : MonoBehaviour {
	public Button m_Submit;

	// Use this for initialization
	void Start () {
		Button btn = m_Submit.GetComponent<Button> ();
		btn.onClick.AddListener (Submit);
	
	}

	void Submit(){
		print ("Game Start");
		Application.LoadLevel ("SelectStage");
	}
}