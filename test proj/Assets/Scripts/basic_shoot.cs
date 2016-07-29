using UnityEngine;
using System.Collections;

public class basic_shoot : MonoBehaviour {
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; //Instantiate the triggerbutton
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	private SteamVR_TrackedObject trackedObj;

	public GameObject projectile;
	public float multiplier;
	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		projectile = GameObject.FindGameObjectWithTag ("Weapon");
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.GetPressDown (triggerButton)) {
			GameObject razor = Instantiate<GameObject> (projectile);
			razor.transform.position = trackedObj.gameObject.transform.position;
			razor.transform.position.rotation = trackedObj.gameObject.transform.rotation;
			Rigidbody razorbody = razor.GetComponent<Rigidbody> ();
			razorbody.AddForce (transform.forward * multiplier);
			razorbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}
	}
}
