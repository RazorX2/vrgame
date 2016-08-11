using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class double_menu_end : MonoBehaviour
{

	// Use this for initialization
	void Awake()
	{

	}

	// Update is called once per frame
	void Update()
	{
		SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
		SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

		if (left.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu) && right.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu))
		{
			Debug.Log("both menu down");
			SceneManager.LoadScene(0);
		}
	}
}