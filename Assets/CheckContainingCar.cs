using UnityEngine;
using System.Collections;

public class CheckContainingCar : MonoBehaviour {
	private const float UPHILL_MAX_SPEED_LIMIT = 20.0f;
	private const float UPHILL_MIN_SPEED_LIMIT = 0.1f; // adjust this const to check velocity more sensitive or not. [0~1]
	private const float MPS_TO_KPH = 3.6f;
	private const int WARN_MAX_SPEED = 0;
	private const int WARN_TIMEOVER = 1;

	GameObject m_Car;
	Rigidbody m_RigidBody;
	BoxCollider m_BoxCol;

	private float m_TimeLimit = 5.0f;
	private float m_CarVelocity;
	private bool m_IsPlayerPassedUphill = false;

	// Use this for initialization
	void Start () {
		GetComponents ();
	}
	
	// Update is called once per frame
	void Update () {
		this.m_CarVelocity = Mathf.Abs (m_Car.GetComponent<Rigidbody> ().velocity.x) * MPS_TO_KPH;	// convert vunit meter per seconds to km per hour
		CheckBound ();
	}

	void CheckBound(){
		if (!m_IsPlayerPassedUphill) {
			if (m_BoxCol.bounds.Contains (m_Car.transform.position)) {
				CheckVelocity ();
			}
		}
	}

	void CheckVelocity(){
		if (this.m_CarVelocity >= UPHILL_MAX_SPEED_LIMIT)
			Warn (WARN_MAX_SPEED);
		else if (this.m_TimeLimit <= 0)
			Warn (WARN_TIMEOVER);
		else if (this.m_CarVelocity < UPHILL_MIN_SPEED_LIMIT) {
			print ("____ ALERT: Car has stopped!");
			StartTimer ();
		this.m_IsPlayerPassedUphill = true;
		}
	}

	void Warn(int WARN_CODE){
		switch (WARN_CODE) {
		case WARN_MAX_SPEED:
			print ("____ WARNING: Velocity is too high.");
			this.m_IsPlayerPassedUphill = true;
			break;
		case WARN_TIMEOVER:
			print ("____ WARNING: Time is over.");
			this.m_IsPlayerPassedUphill = true;
			break;
		}
	}

	void StartTimer(){
		this.m_TimeLimit -= Time.deltaTime;	// - 1.0f to Timelimit per second.
		if (this.m_TimeLimit <= 0)
			this.m_TimeLimit = 5.0f;
		print (this.m_TimeLimit.ToString("F1")); // set decimal format. (0.0)
	}

	void GetComponents(){
		this.m_BoxCol = GetComponent<BoxCollider> ();
		this.m_Car = GameObject.Find ("Car");
	}
}
