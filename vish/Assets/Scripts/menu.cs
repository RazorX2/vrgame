using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	public bool paused;
	private GameObject menuscreen;

	void Start () {
		paused = false;
		menuscreen = GameObject.FindGameObjectWithTag ("Menu");
		menuscreen.SetActive (false);
	}
	
	// Toggles pause menu and world freeze on either controller's menu press.
	void Update () {
		SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
		SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

		//menu on button hold
		if ((left.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu)) && !paused) {
			menuscreen.SetActive (true);
			menuscreen.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
			GameObject controls = menuscreen.transform.Find ("controls").gameObject;
			controls.transform.position = new Vector3(controls.transform.position.x, transform.position.y * 2f / 3, controls.transform.position.z);
			Time.timeScale = 0;
			paused = true;
		} else if ((left.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu)) && paused) {
			Time.timeScale = 1;
			menuscreen.SetActive (false);
			paused = false;
		}

		//highlight buttons using raycast?
//		if (paused) {
//			if (left) {
//			}
//		}
		

		//toggles menu on press
//		if (left.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
//		{
//			if (paused) {
//				Time.timeScale = 1;
//				menuscreen.SetActive (false);
//				paused = false;
//			} else {
//				menuscreen.SetActive (true);
//				menuscreen.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
//				Time.timeScale = 0;
//				paused = true;
//			}
//		}
	}
}
