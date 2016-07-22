using UnityEngine;
using System.Collections;

public class kamikaze : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter(Collision c){		// if an enemy collides with me, it dies.
		if(c.gameObject.tag == "Enemy"){
			Destroy (c.gameObject);
		}
	}
}
