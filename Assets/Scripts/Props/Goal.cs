using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement player;
    public GameObject UIVictory;
    public Text DeathText;
    private int Deaths;
    private int maxDeaths;
    public int level;
    void Start()
    {
       
            maxDeaths = PlayerPrefs.GetInt("deathsLevel" + level);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Deaths = player.GetCountDeath;
            UIVictory.SetActive(true);
            DeathText.text = "Total Deaths: " + Deaths;
            if (Deaths < maxDeaths)
            {
                PlayerPrefs.SetInt("deathsLevel" + level, Deaths);
                PlayerPrefs.Save();
            }
            
        }
    }
}
