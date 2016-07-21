using UnityEngine;
using System.Collections;

public class virus_tracking : MonoBehaviour {
	public GameObject player;
	private Rigidbody vself;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		vself = GetComponent<Rigidbody> ();
	}
	
	// move the virus towards the player once every 90 seconds
	void FixedUpdate () {
		Vector3 heading = player.transform.position - transform.position;
		vself.velocity = heading;
	}
}
