using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class basic_shoot : MonoBehaviour {
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; //Instantiate the triggerbutton
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)(gameObject.GetComponent<SteamVR_TrackedObject>().index)); } }

	private GameObject projectile;
	public float multiplier;
	// Use this for initialization
	void Awake () {
		projectile = GameObject.FindGameObjectWithTag ("Weapon");
	}

	// Update is called once per frame
	void Update () {
		if (controller.GetPressDown (triggerButton)) {
			GameObject razor = Instantiate<GameObject> (projectile);
			razor.transform.position = transform.position;
            razor.transform.rotation = transform.rotation * Quaternion.AngleAxis(-90f, Vector3.right);
			Rigidbody razorbody = razor.GetComponent<Rigidbody> ();
            razorbody.useGravity = true;
			razorbody.AddForceAtPosition(transform.forward * multiplier*3,transform.position,ForceMode.Impulse);
			razorbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		}
	}
    public void TurnOff()
    {
        this.enabled = false;
    }
}
