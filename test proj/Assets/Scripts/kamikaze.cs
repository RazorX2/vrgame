using UnityEngine;
using System.Collections;

public class kamikaze : MonoBehaviour {
    public int power;
    private int health;
	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter(Collision c){     // if an enemy collides with me, it dies.
        if (c.gameObject.tag == "Enemy"){
            health = c.gameObject.GetComponent<Enemy>().hit(power);
            Debug.Log("" + health);
            if (health <= 0)
                Destroy(c.gameObject);
            Destroy(transform.gameObject);
        }
        
	}
    void Update()
    {
        if (transform.position.y < 1)
            Destroy(transform.gameObject);
    }
}
