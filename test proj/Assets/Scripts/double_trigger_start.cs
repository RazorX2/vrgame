using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class double_trigger_start : MonoBehaviour {

	SteamVR_Controller.Device left_controller;
	SteamVR_Controller.Device right_controller;
	// Use this for initialization
	void Awake () {
		left_controller = SteamVR_Controller.Input (1);
		right_controller = SteamVR_Controller.Input (2);
	}
	
	// Update is called once per frame
	void Update () {
		if (left_controller.GetPressDown (SteamVR_Controller.ButtonMask.Trigger) && right_controller.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("Both triggers are being held down.");
			SceneManager.LoadScene (1);
		}
	}
}
