using UnityEngine;
using System.Collections;

public class weapon_kill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter(Collision c) {       // if an enemy collides with me, we both die.
        if (c.gameObject.tag == "Enemy")
        {
            Destroy(c.gameObject);
            Destroy(transform.gameObject);
        }
    }
}
