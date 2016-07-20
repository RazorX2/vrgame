using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	public bool paused;
	private GameObject menuscreen;
	private Animation[] animations;

	void Start () {
		paused = false;
		menuscreen = GameObject.FindGameObjectWithTag ("Menu");
		menuscreen.SetActive (false);
		animations = GetComponents<Animation> ();
	}
	
	// Toggles pause menu and world freeze on either controller's menu press.
	void Update () {
		SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
		SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

		if (left.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
		{
			if (paused) {
				Time.timeScale = 1;
				menuscreen.SetActive (false);
				paused = false;
			} else {
				menuscreen.SetActive (true);
				Time.timeScale = 0;
				paused = true;
			}
		}
	}
}
