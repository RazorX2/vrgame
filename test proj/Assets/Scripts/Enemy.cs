using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private int health,maxhealth;
    public int getHealth { get { return health; } }
	// Use this for initialization
	void Start () {
        maxhealth = 100;
        health = maxhealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public int hit(int damage)
    {
        health -= damage;
        return health;
    }
}
