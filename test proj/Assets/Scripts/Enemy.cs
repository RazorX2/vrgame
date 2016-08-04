using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class Enemy : MonoBehaviour
{
    public int power,maxhealth,speed;
    private int health;
=======
public class Enemy : MonoBehaviour {
    private int health,maxhealth;
>>>>>>> 7391e24f4deb553b360f218544043dac178ad469
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
<<<<<<< HEAD
    void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.tag);
        if (c.gameObject.tag == "Player")
        {
            health = c.gameObject.GetComponent<PlayerChar>().hit(power);
            
        }
    }
=======
>>>>>>> 7391e24f4deb553b360f218544043dac178ad469
}
