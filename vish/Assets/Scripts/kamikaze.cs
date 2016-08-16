﻿using UnityEngine;
using System.Collections;

public class kamikaze : MonoBehaviour {
    public int power;
    private int health;
    public GameObject Player;
    public AudioClip dead;
//	public virus_spawn spawn;
    // Use this for initialization
    void Start () {
//		spawn = GameObject.FindGameObjectWithTag ("Spawner").GetComponent<virus_spawn> ();
	}

	void OnCollisionEnter(Collision c){     // if an enemy collides with me, it dies.
        if (c.gameObject.tag == "Enemy"){
            health = c.gameObject.GetComponent<Enemy>().hit(power);
            //Debug.Log("" + health);
            if (health <= 0)
            {
                Player.GetComponent<PlayerChar>().updateKills();
                AudioSource.PlayClipAtPoint(dead, c.gameObject.transform.position);
                Destroy(c.gameObject);
//				if (spawn.bossSpawned) {
//					spawn.gameObject.SetActive (true);
//				}
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
