﻿using UnityEngine;
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
        Debug.Log("Your Health is " + health);
        if (health <= 0)
        {
            //Debug.Log("You Died");
            GameObject[] spawner = GameObject.FindGameObjectsWithTag("Spawner");
            //Debug.Log(spawner);
            GameObject[] shooters = GameObject.FindGameObjectsWithTag("Shooter");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            //Debug.Log(shooters);
            for (int i = 0; i < shooters.Length; i++) 
                shooters[i].GetComponent<basic_shoot>().TurnOff();
            for(int i=0;i<spawner.Length;i++)
                spawner[i].GetComponent<virus_spawn>().TurnOff();
            for (int i = 0; i < enemies.Length; i++)
                Destroy(enemies[i]);
            
            Losingscreen.text = "You Died"+ Environment.NewLine+"Enemies Killed:" + killCount+Environment.NewLine+"Press both triggers to go to home screen";
            if (left.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu) && right.GetPress(SteamVR_Controller.ButtonMask.ApplicationMenu))
            {
                Debug.Log("both triggers down");
                SceneManager.LoadScene(0);
            }
        }
    }
    public void updateKills()
    {
        killCount++;
        Debug.Log("You've Killed: "+killCount);
    }
    public int hit(int power)
    {
        health -= power;
        return health;
    }
}
