using UnityEngine;
using System.Collections;

public class CarPositionVectors : MonoBehaviour {
	const float NORTH = -90f;
	const float SOUTH = 90f;
	const float WEST = 180f;
	const float EAST = 0f;

	// 경사로 
	public static Vector3 uphillPosition = new Vector3(42.4f, -0.53f, 41f);
	public static Vector3 uphillRotation = new Vector3(0f, NORTH, 0f);

	// 교차로 
	public static Vector3 crossroadPosition = new Vector3(-48.3f, -0.53f, -7.6f);
	public static Vector3 crossroadRotation = new Vector3(0f, SOUTH, 0f);

	// 직각주차 
	public static Vector3 parkingPosition = new Vector3(16f, -0.53f, -7.4f);
	public static Vector3 parkingRotation = new Vector3(0f, SOUTH, 0f);

	// 돌발구간
	public static Vector3 suddenPosition = new Vector3(-48.15f, -0.53f, -1.999837f);
	public static Vector3 suddenRotation = new Vector3(0f, NORTH, 0f);

	// 가속구간
	public static Vector3 accelPosition = new Vector3(-62f, -0.53f, -50.7f);
	public static Vector3 accelRotation = new Vector3(0f, SOUTH, 0f);

	// 전체 스테이지
	public static Vector3 wholestagePosition = new Vector3(42.4f, -0.53f, 41f);
	public static Vector3 wholestageRotation = new Vector3(0f, NORTH, 0f);


}
