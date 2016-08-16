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
    private int level;
    private bool spawnEnd;
    private bool levelEnd;
    private bool levelStarted;
    private float timer;
    public int currOdds;
    public Slider healthBar;
    public Text healthcount;
    int count;
    private GameObject spawnr;
    private int currKill;
    public Text kills;
    private int maxCurrK;
    // Use this for initialization
    void Start () {
        maxhealth = 100;
        health = maxhealth;
        level = 1;
        spawnEnd = false;
        levelEnd = false;
        levelStarted = true;
        timer = 60;
        count = 0;
        spawnr = GameObject.FindGameObjectWithTag("Spawner");
        spawnr.GetComponent<virus_spawn>().changeOdds(currOdds);
        currKill = 0;
        maxCurrK = 5;
        GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
        GameObject[] shooters = GameObject.FindGameObjectsWithTag("Shooter");
        for (int i = 0; i < shooters.Length; i++)
            shooters[i].GetComponent<basic_shoot>().TurnOn();
        for (int i = 0; i < spawner.Length; i++)
            spawner[i].GetComponent<virus_spawn>().TurnOn();


        }

	// Update is called once per frame
	void Update () {
        /************Level Creation****************/
        timer -= Time.deltaTime;
        if(maxCurrK<=currKill&&!spawnEnd)//if One Minute has passed
        {
            Debug.Log("Time Trigger");
            Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length + " Enemies Left");
            GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].GetComponent<virus_spawn>().TurnOff();//Stop Spawning viruses
            }
            spawnEnd = true;
            levelEnd = false;
            levelStarted = false;
            count = 0;
            
        }
        if(spawnEnd && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)//After spawning has ended and you killed all of the enemies
        {
            //Debug.Log("Level End Trigger");
            levelEnd = true;
            GameObject[] shooters = GameObject.FindGameObjectsWithTag("Shooter");//Close ability to shoot
            for (int i = 0; i < shooters.Length; i++)
                shooters[i].GetComponent<basic_shoot>().TurnOff();
            Losingscreen.text = "Level "+level+" completed\nPress both triggers to start next level";
            if (left.GetPress(SteamVR_Controller.ButtonMask.Trigger) && right.GetPress(SteamVR_Controller.ButtonMask.Trigger))//if both triggers are pulled start next level
            {
                count += 1;
                Debug.Log("Trigger Pressed");
                if (count > 5)
                {
                    currKill = 0;
                    maxCurrK = maxCurrK + (int)(.1*(80 - maxCurrK));
                    levelStarted = true;
                    level += 1;
                    count = 0;
                    health = 100;
                    healthBar.value = health;
                    healthcount.text = "Health:" + health + "/100";
                }
            }
            else
                count = 0;
        }
        if (spawnEnd && levelEnd && levelStarted)//After you ask to start the next level
        {
            //Debug.Log("New Level Trigger");
            Losingscreen.text = "";
            currOdds = (int)(30 - (30 - currOdds * .9));
            spawnr.GetComponent<virus_spawn>().changeOdds(currOdds);
            GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
            GameObject[] shooters = GameObject.FindGameObjectsWithTag("Shooter");
            for (int i = 0; i < shooters.Length; i++) 
                shooters[i].GetComponent<basic_shoot>().TurnOn();
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].GetComponent<virus_spawn>().TurnOn();
                spawner[i].GetComponent<virus_spawn>().changeOdds(currOdds);
                spawner[i].GetComponent<virus_spawn>().delay = (int)(spawner[i].GetComponent<virus_spawn>().delay * .95);
            }
            spawnEnd = false;
            levelEnd = false;
            levelStarted = true;
            timer = 60;

        }
        /************Level Creation****************/
        /********End Game Scenerio****************/
        if (health <= 0)
        {
            //Debug.Log("Death triggered");
            GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
            GameObject[] shooters = GameObject.FindGameObjectsWithTag("Shooter");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < shooters.Length; i++)
                shooters[i].GetComponent<basic_shoot>().TurnOff();
            for(int i=0;i<spawner.Length;i++)
                spawner[i].GetComponent<virus_spawn>().TurnOff();
            for (int i = 0; i < enemies.Length; i++)
                Destroy(enemies[i]);

            Losingscreen.text = "You Got to level "+level+"\nEnemies Killed:" + killCount+"\nPress both triggers to go to home screen";

            if (left.GetPress(SteamVR_Controller.ButtonMask.Trigger) && right.GetPress(SteamVR_Controller.ButtonMask.Trigger))
            {
                //count++;
                //if (count > 5)
                {
                    Debug.Log("both triggers down");
                    SceneManager.LoadScene(0);
                }
            }
        }
        /********End Game Scenerio****************/
    }
    public void updateKills()
    {
        killCount++;
        currKill++;
        kills.text = "Kills: " + killCount;
    }
    public int hit(int power)
    {
        health -= power;
        if (health < 0)
            health = 0;
        healthBar.value = health;
        healthcount.text = "Health:" + health + "/100";
        return health;
    }
}
