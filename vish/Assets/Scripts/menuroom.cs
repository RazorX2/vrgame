using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class menuroom : MonoBehaviour {
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
        Time.timeScale = 1;
		menuscreen.SetActive (false);
		myEventSystem = GameObject.Find("EventSystem").GetComponent<UnityEngine.EventSystems.EventSystem> ();
	}
	
	// pauses menu and world freeze on either controller's menu press.
	void Update () {
		SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
		SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

		//menu on button hold, save initial controller rotation, always spawn menu in front @  2/3 height
		if ((left.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) && !paused) {
			pauseRotation = left.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu) ? left.transform.rot : right.transform.rot;
			leftbutt = left.GetPress (SteamVR_Controller.ButtonMask.ApplicationMenu) ? true : false;

			menuscreen.SetActive (true);
			menuscreen.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
			GameObject controls = menuscreen.transform.Find ("controls").gameObject;
			controls.transform.position = new Vector3(transform.position.x + transform.forward.x, transform.position.y * 2f / 3, transform.position.z + transform.forward.z);
            controls.transform.rotation = Quaternion.Euler(30, transform.rotation.eulerAngles.y, controls.transform.rotation.eulerAngles.z);

			Time.timeScale = 0;
			paused = true;
		} else if ((left.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu) || right.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) && paused) {
			Time.timeScale = 1;
			menuscreen.SetActive (false);
			paused = false;
		}

        //		highlight buttons using y-rotation angle of controller whose button is down
        if (paused)
        {
            if (leftbutt)
            {
                //if (Mathf.Atan2(left.transform.rot.eulerAngles.x, left.transform.rot.eulerAngles.z) < Mathf.Atan2(pauseRotation.eulerAngles.x, pauseRotation.eulerAngles.z))
                if (left.transform.rot.eulerAngles.x > 0 && left.transform.rot.eulerAngles.x < 90)
                {
                    Debug.Log("left tilted up");
                    deselect(top.gameObject);
                    top.Select();
                    if (left.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                    {
                        botLoad();
                    }
                }
                else if (left.transform.rot.eulerAngles.x > 270 && left.transform.rot.eulerAngles.x < 360)
                {
                    deselect(bot.gameObject);
                    Debug.Log("left tilted down");
                    bot.Select();
                    if (left.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                    {
                        Time.timeScale = 1;
                        menuscreen.SetActive(false);
                        paused = false;
                        topLoad();
                    }
                }

            }
            else
            {
                if (right.transform.rot.eulerAngles.x > 270 && right.transform.rot.eulerAngles.x < 360)
                {
                    Debug.Log("right tilted up");
                    deselect(bot.gameObject);
                    bot.Select();
                    if (right.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                    {
                        topLoad();
                    }
                }
                else if (right.transform.rot.eulerAngles.x > 0 && right.transform.rot.eulerAngles.x < 90)
                {
                    deselect(top.gameObject);
                    Debug.Log("right tilted down");
                    top.Select();
                    if (right.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                        botLoad();
                }

                
            }
        }
	}

	void deselect(GameObject current){
		if (myEventSystem.currentSelectedGameObject != current) {
			myEventSystem.SetSelectedGameObject (null);
		}
	}

	//what the top button does
	void topLoad(){
        Debug.Log("Go to Scene");
		SceneManager.LoadScene(1);
	}

	//what the bottom button does
	void botLoad(){
        SceneManager.LoadScene(0);
        Debug.Log("Quit");
	}
}
