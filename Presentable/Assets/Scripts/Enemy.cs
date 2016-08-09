using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int power;
    private int health, maxhealth;
    public int getHealth { get { return health; } }
    // Use this for initialization
    void Start()
    {
        maxhealth = 100;
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public int hit(int damage)
    {
        health -= damage;
        return health;
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            health = c.gameObject.GetComponent<PlayerChar>().hit(power);
            
        }
    }
}
