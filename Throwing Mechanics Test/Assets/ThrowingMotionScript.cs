using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowingMotionScript : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip; //Instantiate the Gripbutton
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; //Instantiate the triggerbutton

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private GameObject pickup;
    // Use this for initialization
    void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.GetPressDown(gripButton)&&pickup!=null)
        {
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().isKinematic = true;
        }
        if(controller.GetPressUp(gripButton)&&pickup!=null)
        {
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (controller.GetPressDown(triggerButton)&&controller.GetPressDown(gripButton) && pickup != null) {
            pickup.GetComponent<Rigidbody>().AddForce(Vector3.up * 100+ Vector3.forward*100, ForceMode.Acceleration);
            pickup.GetComponent<Rigidbody>().angularVelocity = Vector3.one * 100;
            pickup.GetComponent<Rigidbody>().useGravity = true;
        }
	}
    private void OnTriggerEnter(Collider collider)
    {
        pickup = collider.gameObject;
    }
    private void OnTriggerExit(Collider collider)
    {
        pickup = null;
    }
 
}
