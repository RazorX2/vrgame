using UnityEngine;
using System.Collections;

public class kamikaze : MonoBehaviour {
    public int power;
    private int health;
	private AudioClip dead;
    public GameObject Player;
	// Use this for initialization
	void Awake () {
		dead = Resources.Load ("Audio/virus die.mp3") as AudioClip;
	}

	void OnCollisionEnter(Collision c){     // if an enemy collides with me, it dies.
        if (c.gameObject.tag == "Enemy"){
            health = c.gameObject.GetComponent<Enemy>().hit(power);
            Debug.Log("" + health);
            if (health <= 0)
            {
                Player.GetComponent<PlayerChar>().updateKills();
				AudioSource.PlayClipAtPoint (dead, c.gameObject.transform.position);
                Destroy(c.gameObject);
            }
            Destroy(transform.gameObject);
        }
        if(c.gameObject.tag == "plan"){
            Destroy(this.gameObject);
        }

	}
    void Update()
    {
        //if (transform.position.y < 1)
            //Destroy(transform.gameObject);
    }
}
