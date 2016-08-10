using UnityEngine;
using System.Collections;

public class virus_tracking : MonoBehaviour {
	public GameObject player;
	private Rigidbody vself;
    private int speed;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		vself = GetComponent<Rigidbody> ();
        speed = this.gameObject.GetComponent<Enemy>().speed;
	}
	
	// move the virus towards the player once every 90 seconds
	void FixedUpdate () {
		Vector3 heading = speed*(float).1*Vector3.Scale(player.transform.position - transform.position, (Vector3.right + Vector3.forward));
		vself.velocity = heading;
	}
    public void TurnOff()
    {
        this.enabled = false;
    }
}
