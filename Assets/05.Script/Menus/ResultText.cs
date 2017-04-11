using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultText : MonoBehaviour {
	void Awake(){
		SetResultText();
	}

	void SetResultText(){
		// 메뉴에 출력되는 텍스트를 받아옵니다. (연석 충돌 또는 감점으로 인한 실격)
		this.GetComponent<Text> ().text = GameMenus.resultText;
	}
}
