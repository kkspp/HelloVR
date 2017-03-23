using UnityEngine;
using System;




public class GvrReticlePointerImpl : GvrBasePointer
{
	
	// HelloVr
	public float gazeTime = 3.0f;


	

	// The constants below are expsed for testing.
	// Minimum inner angle of the reticle (in degrees).
	public const float RETICLE_MIN_INNER_ANGLE = 0.0f;
	// Minimum outer angle of the reticle (in degrees).
	public const float RETICLE_MIN_OUTER_ANGLE = 0.5f;
	// Angle at which to expand the reticle when intersecting with an object
	// (in degrees).
	public const float RETICLE_GROWTH_ANGLE = 1.5f;

	// Minimum distance of the reticle (in meters).
	public const float RETICLE_DISTANCE_MIN = 0.45f;
	// Maximum distance of the reticle (in meters).
	public const float RETICLE_DISTANCE_MAX = 10.0f;

	/// Growth speed multiplier for the reticle.
	public float ReticleGrowthSpeed { private get; set; }

	public Material MaterialComp { private get; set; }

	// Current inner angle of the reticle (in degrees).
	// Exposed for testing.
	public float ReticleInnerAngle { get; private set; }

	// Current outer angle of the reticle (in degrees).
	// Exposed for testing.
	public float ReticleOuterAngle { get; private set; }

	// Current distance of the reticle (in meters).
	// Getter exposed for testing.
	public float ReticleDistanceInMeters { get; private set; }

	// Current inner and outer diameters of the reticle, before distance multiplication.
	// Getters exposed for testing.
	public float ReticleInnerDiameter { get; private set; }

	public float ReticleOuterDiameter { get; private set; }

	public override float MaxPointerDistance {
		get {
			return RETICLE_DISTANCE_MAX;
		}
	}


	public GvrReticlePointerImpl ()
	{
		ReticleGrowthSpeed = 8.0f;
		ReticleInnerAngle = 0.0f;
		ReticleOuterAngle = 0.5f;
		ReticleDistanceInMeters = 10.0f;
		ReticleInnerDiameter = 0.0f;
		ReticleOuterDiameter = 0.0f;
	}

	public override void OnStart ()
	{
		base.OnStart ();
	}

	/// This is called when the 'BaseInputModule' system should be enabled.
	public override void OnInputModuleEnabled ()
	{
	}

	/// This is called when the 'BaseInputModule' system should be disabled.
	public override void OnInputModuleDisabled ()
	{
	}

	/// Called when the user is pointing at valid GameObject. This can be a 3D
	/// or UI element.
	///
	/// The targetObject is the object the user is pointing at.
	/// The intersectionPosition is where the ray intersected with the targetObject.
	/// The intersectionRay is the ray that was cast to determine the intersection.
	public override void OnPointerEnter (GameObject targetObject, Vector3 intersectionPosition,
	                                     Ray intersectionRay, bool isInteractive)
	{
		
		SetPointerTarget (intersectionPosition, isInteractive);

	}
		
	
	/// Called every frame the user is still pointing at a valid GameObject. This
	/// can be a 3D or UI element.
	///
	/// The targetObject is the object the user is pointing at.
	/// The intersectionPosition is where the ray intersected with the targetObject.
	/// The intersectionRay is the ray that was cast to determine the intersection.
	public override void OnPointerHover (GameObject targetObject, Vector3 intersectionPosition,
	                                     Ray intersectionRay, bool isInteractive)
	{

		SetPointerTarget (intersectionPosition, isInteractive);
		gazeTime -= Time.deltaTime;
		if (gazeTime < 0 && GameMenus.isPlayerSelectingMenus) {
			MenuEvents (targetObject.name);
		} else if(gazeTime < 0 && !GameMenus.isPlayerSelectingMenus){
			LoadStage(targetObject.name);
		}

	}

	void LoadStage(string targetName){
		switch (targetName) {
		case "Uphill":
			CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Uphill;
			Debug.Log ("uphil");
			break;
		case "Crossroad":
			CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Crossroad;
			break;
		case "Parking":
			CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Parking;
			break;
		case "Sudden":
			CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Sudden;
			break;
		case "Accel":
			CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.Accel;
			break;
		case "WholeStage":
			CarPositionInit.selectedStage = (int)CarPositionEnum.StageType.WholeStage	;
			break;
		default:
			break;
		}
		Application.LoadLevel ("Driving");
	}

	void MenuEvents(string targetName){
		switch (targetName) {
		case "NewGame":
			Application.LoadLevel ("Login");
			break;
		case "ToSelectStage":
			Application.LoadLevel ("SelectStage");
			break;
		case "Retry":
			Application.LoadLevel ("Driving");
			break;
		default:
			break;
		}
		GameMenus.isPlayerSelectingMenus = false;
	}

	/// Called when the user's look no longer intersects an object previously
	/// intersected with a ray projected from the camera.
	/// This is also called just before **OnInputModuleDisabled** and may have have any of
	/// the values set as **null**.
	public override void OnPointerExit (GameObject targetObject)
	{
		ReticleDistanceInMeters = RETICLE_DISTANCE_MAX;
		ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE;
		ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE;
		gazeTime = 3.0f;
	}

	/// Called when a trigger event is initiated. This is practically when
	/// the user begins pressing the trigger.
	public override void OnPointerClickDown ()
	{
	}

	/// Called when a trigger event is finished. This is practically when
	/// the user releases the trigger.
	public override void OnPointerClickUp ()
	{
	}

	public override void GetPointerRadius (out float enterRadius, out float exitRadius)
	{
		float min_inner_angle_radians = Mathf.Deg2Rad * RETICLE_MIN_INNER_ANGLE;
		float max_inner_angle_radians = Mathf.Deg2Rad * (RETICLE_MIN_INNER_ANGLE + RETICLE_GROWTH_ANGLE);

		enterRadius = 2.0f * Mathf.Tan (min_inner_angle_radians);
		exitRadius = 2.0f * Mathf.Tan (max_inner_angle_radians);
	}

	public void UpdateDiameters ()
	{
		ReticleDistanceInMeters =
      Mathf.Clamp (ReticleDistanceInMeters, RETICLE_DISTANCE_MIN, RETICLE_DISTANCE_MAX);

		if (ReticleInnerAngle < RETICLE_MIN_INNER_ANGLE) {
			ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE;
		}

		if (ReticleOuterAngle < RETICLE_MIN_OUTER_ANGLE) {
			ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE;
		}

		float inner_half_angle_radians = Mathf.Deg2Rad * ReticleInnerAngle * 0.5f;
		float outer_half_angle_radians = Mathf.Deg2Rad * ReticleOuterAngle * 0.5f;

		float inner_diameter = 2.0f * Mathf.Tan (inner_half_angle_radians);
		float outer_diameter = 2.0f * Mathf.Tan (outer_half_angle_radians);

		ReticleInnerDiameter =
        Mathf.Lerp (ReticleInnerDiameter, inner_diameter, Time.deltaTime * ReticleGrowthSpeed);
		ReticleOuterDiameter =
        Mathf.Lerp (ReticleOuterDiameter, outer_diameter, Time.deltaTime * ReticleGrowthSpeed);

		MaterialComp.SetFloat ("_InnerDiameter", ReticleInnerDiameter * ReticleDistanceInMeters);
		MaterialComp.SetFloat ("_OuterDiameter", ReticleOuterDiameter * ReticleDistanceInMeters);
		MaterialComp.SetFloat ("_DistanceInMeters", ReticleDistanceInMeters);
	}

	private bool SetPointerTarget (Vector3 target, bool interactive)
	{
		if (base.PointerTransform == null) {
			Debug.LogWarning ("Cannot operate on a null pointer transform");
			return false;
		}
		Vector3 targetLocalPosition = base.PointerTransform.InverseTransformPoint (target);

		ReticleDistanceInMeters =
        Mathf.Clamp (targetLocalPosition.z, RETICLE_DISTANCE_MIN, RETICLE_DISTANCE_MAX);
		if (interactive) {
			ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE + RETICLE_GROWTH_ANGLE;
			ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE + RETICLE_GROWTH_ANGLE;
		} else {
			ReticleInnerAngle = RETICLE_MIN_INNER_ANGLE;
			ReticleOuterAngle = RETICLE_MIN_OUTER_ANGLE;
		}
		return true;
	}
}
