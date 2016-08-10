using UnityEngine;
using System.Collections;

//RequireComponent(typeof(SteamVR_TrackedObject))]
public class right_trigger_test : MonoBehaviour {

	//SteamVR_TrackedObject controller;
	// Use this for initialization
	void Awake () {
		//controller = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
        SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

        if (left.GetTouch (SteamVR_Controller.ButtonMask.Trigger)) {
			Debug.Log ("left trigger partly down");
        }
        if (right.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("right trigger partly down");
        }
    }
}
