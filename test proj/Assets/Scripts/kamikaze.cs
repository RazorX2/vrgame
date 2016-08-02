using UnityEngine;
using System.Collections;

public class kamikaze : MonoBehaviour {
    public int power;
	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter(Collision c){		// if an enemy collides with me, it dies.
		if(c.gameObject.tag == "Enemy"){
            if (c.gameObject.GetComponent<Enemy>().hit(power) > 0) ;
            else
                Destroy(c.gameObject);
		}
	}
}
