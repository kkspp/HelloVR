using UnityEngine;
using System.Collections;

public class CarCollideCheck : MonoBehaviour {

	// Car에 콜라이더를 달아줍니다.
	void OnCollisionEnter(Collision other)
	{
		// 충돌 물체가 연석이라면...
		if(other.gameObject.tag == "CurbStone"){
			// 게임 메뉴 스크립트에 플레이어가 메뉴 선택을 하고 있다고 알리고
			GameMenus.isPlayerSelectingMenus = true;

			// 메뉴에 출력할 텍스트를 설정합니다. 
			GameMenus.resultText = "연석 충돌로 인한 실격입니다!";

			// 메뉴 선택 씬을 로드합니다...
			Application.LoadLevel ("MenusWhenPlayerFails");


		}
	}
}
