using UnityEngine;
using System.Collections;

public class throw_physics : MonoBehaviour {
	private Valve.VR.EVRButtonId touchButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad; //Instantiate the touchpad
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; //Instantiate the triggerbutton
	private float vMultiplier = 100f; // how fast objects follow the controller
	private bool grabbed = false;
	private Vector3[] pastPositions = {Vector3.zero, Vector3.zero, Vector3.zero, Vector3.zero};

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)(gameObject.GetComponent<SteamVR_TrackedObject>().index)); } }

	void Start () {		// Use this for initialization
	}

	void OnCollisionEnter(Collision c){		// trigger haptic feedback
        OnCollisionStay(c);
	}

	void OnCollisionStay(Collision c){		// move object to controller
        Debug.Log("Collision Detected");
		if (c.gameObject.GetComponent<Rigidbody>() != null && c.gameObject.tag == "Weapon") {		
			Rigidbody obj = c.gameObject.GetComponent<Rigidbody>();
            Debug.Log("In Rigidbody");

			if (controller.GetPress(touchButton) && controller.GetPress (triggerButton)) {
                Debug.Log("Grabbed");
				Vector3 deltaPosition = c.transform.position - transform.position;
				obj.velocity = deltaPosition * vMultiplier * Time.fixedDeltaTime;
				grabbed = true;
			} else if (grabbed) {
                Debug.Log("Let Go");
				grabbed = false;
				obj.velocity = GetAveragedVelocity (pastPositions);
			}
		}
	}

	void Update () {	// updates controllers last 4 positions for velocity
		pastPositions[3] = pastPositions[2];
		pastPositions[2] = pastPositions[1];
		pastPositions [1] = pastPositions [0];
        pastPositions[0] = transform.position;
	}

	public Vector3 GetAveragedVelocity(Vector3[] p){
		Vector3 avgVel = (p [3] - p [2]) + (p [2] - p [1]) + (p [1] - p [0]) / 3.0f;
		return avgVel;
	}
}
