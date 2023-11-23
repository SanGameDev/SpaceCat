using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCount : MonoBehaviour
{
    public int level;
    public Text deathsText;
    private int deaths;
    private void Start()
    { 
        
        deaths = PlayerPrefs.GetInt("deathsLevel" + level.ToString());
       
        updateDeaths(deaths);
        
    }
    
    private void updateDeaths(int deaths)
    {
        // Actualiza el texto en la UI con el puntaje actual.
        if (deathsText != null)
        {
            deathsText.text = "Deaths: " + deaths;
        }
    }
}
