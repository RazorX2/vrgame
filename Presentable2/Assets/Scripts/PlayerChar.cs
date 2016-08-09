using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class PlayerChar : MonoBehaviour {
    private int maxhealth, health;
    public int getHealth { get{ return health; } }
    private int killCount;
    public Text Losingscreen;
    SteamVR_Controller.Device left = SteamVR_Controller.Input(3);
    SteamVR_Controller.Device right = SteamVR_Controller.Input(4);

    // Use this for initialization
    void Start () {
        maxhealth = 100;
        health = maxhealth;
	}

	// Update is called once per frame
	void Update () {
        //Debug.Log("Health: " + health);
        if (health <= 0)
        {
<<<<<<< HEAD
            //Debug.Log("You Died");
=======
            Debug.Log("You Died");
>>>>>>> Andrew
            GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
            //Debug.Log(spawner);
            GameObject[] shooters = GameObject.FindGameObjectsWithTag("Shooter");
            //Debug.Log(shooters);
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < shooters.Length; i++)
                shooters[i].GetComponent<basic_shoot>().TurnOff();
            for(int i=0;i<spawner.Length;i++)
                spawner[i].GetComponent<virus_spawn>().TurnOff();
            for (int i = 0; i < enemies.Length; i++)
                Destroy(enemies[i]);
<<<<<<< HEAD
            Losingscreen.text = "You Died\nEnemies Killed:" + killCount+"\nPress both triggers to go to home screen";
            if (left.GetPress(SteamVR_Controller.ButtonMask.Trigger) && right.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("both triggers down");
                SceneManager.LoadScene(0);
=======
            Losingscreen.text = "You Died\nEnemies Killed:" + killCount"\nPress both triggers to go to home screen";
            if (left.GetPress(SteamVR_Controller.ButtonMask.Trigger) && right.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                Debug.Log("both triggers down");
                SceneManager.LoadScene(1);
>>>>>>> Andrew
            }
        }
    }
    public void updateKills()
    {
        killCount++;
    }
    public int hit(int power)
    {
        health -= power;
        return health;
    }
}
