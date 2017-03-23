using UnityEngine;
using System.Collections;

public class CarPositionVectors : MonoBehaviour {
	const float NORTH = -90f;
	const float SOUTH = 90f;
	const float WEST = 180f;
	const float EAST = 0f;
		
	public static Vector3 uphillPosition = new Vector3(42.4f, 0.1f, 41f);
	public static Vector3 uphillRotation = new Vector3(0f, NORTH, 0f);

	public static Vector3 crossroadPosition = new Vector3(-48.3f, 0.1f, -7.6f);
	public static Vector3 crossroadRotation = new Vector3(0f, SOUTH, 0f);

	public static Vector3 parkingPosition = new Vector3(16f, 0.1f, -7.4f);
	public static Vector3 parkingRotation = new Vector3(0f, SOUTH, 0f);

	public static Vector3 suddenPosition = new Vector3(36.4f, 0.1f, -45.5f);
	public static Vector3 suddenRotation = new Vector3(0f, NORTH, 0f);

	public static Vector3 accelPosition = new Vector3(-62f, 0.1f, -50.7f);
	public static Vector3 accelRotation = new Vector3(0f, SOUTH, 0f);

	public static Vector3 wholestagePosition = new Vector3(42.4f, 0.1f, 41f);
	public static Vector3 wholestageRotation = new Vector3(0f, NORTH, 0f);
}
