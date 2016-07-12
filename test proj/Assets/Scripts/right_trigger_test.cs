using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class right_trigger_test : MonoBehaviour {

	SteamVR_TrackedObject controller;
	// Use this for initialization
	void Awake () {
		controller = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		SteamVR_Controller.Device device = SteamVR_Controller.Input ((int)controller.index);

		if (device.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Trigger partly down");
		}
	}
}
