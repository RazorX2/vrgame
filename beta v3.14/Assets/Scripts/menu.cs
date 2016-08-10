using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class menu : MonoBehaviour {
	private bool paused;
	private bool leftbutt;
	private Quaternion pauseRotation;
	private GameObject menuscreen;
	private EventSystem myEventSystem;
	public Button top;
	public Button bot;
//	public GameObject leftgo;
//	public GameObject rightgo;

	void Start () {
		paused = false;
		menuscreen = GameObject.FindGameObjectWithTag ("Menu");
		menuscreen.SetActive (false);
		myEventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem> ();
	}
	
	// pauses menu and world freeze on either controller's menu press.
	void Update () {
		SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
		SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

		//menu on button hold, save initial controller rotation, always spawn menu in front @  2/3 height
		if ((left.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu)) && !paused) {
			pauseRotation = left.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu) ? left.transform.rot : right.transform.rot;
			leftbutt = left.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu) ? true : false;

			menuscreen.SetActive (true);
			menuscreen.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
			GameObject controls = menuscreen.transform.Find ("controls").gameObject;
			controls.transform.position = new Vector3(transform.position.x + transform.forward.x, transform.position.y * 2f / 3, transform.position.z + transform.forward.z);
			controls.transform.rotation = Quaternion.Euler(30, -transform.rotation.y, controls.transform.rotation.z);

			Time.timeScale = 0;
			paused = true;
		} else if ((left.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPressUp (SteamVR_Controller.ButtonMask.ApplicationMenu)) && paused) {
			Time.timeScale = 1;
			menuscreen.SetActive (false);
			paused = false;
		}

//		highlight buttons using y-rotation angle of controller whose button is down
		if (paused) {
			if (leftbutt) {
				if (Mathf.Atan2(-left.transform.rot.eulerAngles.y, left.transform.rot.eulerAngles.x) > Mathf.Atan2(-pauseRotation.eulerAngles.y, pauseRotation.eulerAngles.x)) {
					deselect (top.gameObject);
					top.Select ();
					if (left.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
						topLoad ();
					}
				} else {
					deselect (bot.gameObject);
					bot.Select ();
					if (right.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
						botLoad ();
					}
				}
					
			} else{
				if (Mathf.Atan2(-right.transform.rot.eulerAngles.y, right.transform.rot.eulerAngles.x) > Mathf.Atan2(-pauseRotation.eulerAngles.y, pauseRotation.eulerAngles.x)) {
					deselect (top.gameObject);
					top.Select ();
					if (left.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
						topLoad ();
					}
				} else {
					deselect (bot.gameObject);
					bot.Select ();
					if (right.GetPressDown (SteamVR_Controller.ButtonMask.Trigger)) {
						botLoad ();
					}
				}
			}
		}
		

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

//	void LateUpdate(){
//		if(top.is
//	}

	void deselect(GameObject current){
		if (myEventSystem.currentSelectedGameObject != current) {
			myEventSystem.SetSelectedGameObject (null);
		}
	}

	//what the top button does
	void topLoad(){
		SceneManager.LoadScene (1);
	}

	//what the bottom button does
	void botLoad(){
		Application.Quit ();
	}
}
