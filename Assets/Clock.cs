using System.Collections;
using System.Collections.Generic;


/*public class Clock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
*/ 
using System;
using UnityEngine;

public class Clock : MonoBehaviour {

	const float degreesPerHour= 30f;
	const float degreesPerMinute= 6f;
	const float degreesPerSecond= 6f;

	public bool continuous;

	public Transform hoursTransform, minutesTransform, secondsTransform;

	//void Awake() {Debug.Log (DateTime.Now.Hour);}

	void Update() {
		if (continuous== true) {UpdateContinuous();}
		else {UpdateDiscrete();}
	}



	void UpdateContinuous() {

		TimeSpan time= DateTime.Now.TimeOfDay;
		DateTime stime= DateTime.Now;
	
		hoursTransform.localRotation =
			Quaternion.Euler (0f, (float)time.TotalHours * degreesPerHour, 0f);
	
		minutesTransform.localRotation =
			Quaternion.Euler (0f, (float)time.TotalMinutes * degreesPerMinute, 0f);

		secondsTransform.localRotation =
			Quaternion.Euler (0f, stime.Second * degreesPerSecond, 0f);

	}

	void UpdateDiscrete() {

		DateTime time= DateTime.Now;

		hoursTransform.localRotation =
			Quaternion.Euler (0f, time.Hour * degreesPerHour, 0f);

		minutesTransform.localRotation =
			Quaternion.Euler (0f, time.Minute * degreesPerMinute, 0f);

		secondsTransform.localRotation =
			Quaternion.Euler (0f, time.Second * degreesPerSecond, 0f);

	}





}