using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThrowingMotionScript : MonoBehaviour {

    private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip; //Instantiate the Gripbutton
    private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; //Instantiate the triggerbutton

    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
    private SteamVR_TrackedObject trackedObj;

    private GameObject pickup;
    private bool canShoot = false;
    private bool justShot = false;
    // Use this for initialization
    void Start () {

        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.GetPressDown(gripButton)&&pickup!=null&&!canShoot)
        {
            print("You just picked it up");
            pickup.transform.parent = this.transform;
            pickup.GetComponent<Rigidbody>().isKinematic = true;
            canShoot = true;
        }
        if(controller.GetPressUp(gripButton)&&pickup!=null&&canShoot&&!justShot)
        {
            print("You dropped it");
            pickup.transform.parent = null;
            pickup.GetComponent<Rigidbody>().useGravity = false;
            pickup.GetComponent<Rigidbody>().isKinematic = false;
            canShoot = false;
        }
        if (controller.GetPressDown(triggerButton)&&controller.GetPress(gripButton) && pickup != null&&canShoot&&!justShot) {
            print("You tried to throw it");
            pickup.GetComponent<Rigidbody>().isKinematic = false;
            pickup.GetComponent<Rigidbody>().useGravity = true;
            //pickup.GetComponent<Rigidbody>().velocity = Vector3.forward * 10 + Vector3.up * 10;
            pickup.GetComponent<Rigidbody>().angularVelocity = Vector3.forward * 100000;
            pickup.GetComponent<Rigidbody>().AddForce(Vector3.up* 10 + Vector3.left*10, ForceMode.Impulse);
            canShoot = false;
            justShot = true;
            
        }
        if (!canShoot && justShot)
        {
            if (pickup.transform.position.y < .5)
            {
                print("I'm dying");
                pickup.GetComponent<Rigidbody>().useGravity = false;
                pickup.GetComponent<Rigidbody>().isKinematic = true;
                pickup.GetComponent<Rigidbody>().velocity = Vector3.zero;
                pickup.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            }
        }
	}
    private void OnTriggerEnter(Collider collider)
    {
        pickup = collider.gameObject;
        print("You interacted with it");
    }
    private void OnTriggerExit(Collider collider)
    {
        pickup = null;
    }
}
