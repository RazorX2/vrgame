using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int power,maxhealth,speed;
    private int health;
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
        this.transform.position = new Vector3(transform.position.x-(float).1,this.transform.position.y,this.transform.position.z-(float).1); 
        return health;
    }
    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.tag == "Player")
        {
            health = c.gameObject.GetComponent<PlayerChar>().hit(power);
            Destroy(this.gameObject);
            
        }
    }
}
