using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tutorial : MonoBehaviour {
	public GameObject l;
	public GameObject r;
	private SteamVR_Controller.Device left;
	private SteamVR_Controller.Device right;
	private GameObject plate;
	private int stage = 0;
	// Use this for initialization
	void Awake () {
		left = l.GetComponent<basic_shoot> ().controller;
		right = r.GetComponent<basic_shoot> ().controller;
		plate = GameObject.Find ("tut");
	}
	
	// Update is called once per frame
	void Update () {
		plate.transform.position = new Vector3(transform.position.x + transform.forward.x, transform.position.y * 2f / 3, transform.position.z + transform.forward.z);
		plate.transform.rotation = Quaternion.Euler(30, transform.rotation.eulerAngles.y, plate.transform.rotation.eulerAngles.z);
		if(TriggerPressed())
			NextStep ();
			
	}

	public bool TriggerPressed(){
		return left.GetPressDown (SteamVR_Controller.ButtonMask.Trigger) || right.GetPressDown (SteamVR_Controller.ButtonMask.Trigger) ? true : false;
	}

	public void NextStep(){
		stage++;
		switch (stage) {
		case 2:
			Text instruct = plate.transform.GetChild (0).gameObject.GetComponentInChildren<Text> ();
			instruct.text = "Both triggers can shoot.\nNow shoot the virus!\n(P.S. It takes 4 hits to kill)";
			break;
		case 3:
			break;
		}
	}
}
