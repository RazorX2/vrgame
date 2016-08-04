using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class movetest : MonoBehaviour {
	private static Rigidbody vRigid;
	// Use this for initialization
	void Start () {
		vRigid = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");

		Vector3 move = v * Vector3.forward + h * Vector3.right;
		vRigid.velocity = move; 
	}
}
