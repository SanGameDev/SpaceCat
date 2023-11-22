using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenSystem : MonoBehaviour
{

    [SerializeField] private float oxygen;

    public Image oxygenBar;

    public float maxOxygen;

    public float oxygenDecreaseSpeed = 1.0f;


    void Start()
    {
        StartCoroutine(DecreaseOxygen());
        oxygen = maxOxygen;
    }

    
    void Update()
    {
        Asfixia();

        oxygenBar.fillAmount = oxygen / maxOxygen;

        limitOxygen();
    }


    void limitOxygen()
    {
        if (oxygen >= 101)
        {
            oxygen = 100;
        }
    }

    IEnumerator DecreaseOxygen()
    {
        while (true)
        {
            oxygen -= oxygenDecreaseSpeed * Time.deltaTime;

            yield return null;
        }
    }

    void Asfixia()
    {
        if (oxygen <= 0)
        {
            Debug.Log("Te has quedado sin oxigeno");
            Destroy(gameObject, 0f);
        }
    }

    public void darOxigeno(float _oxigeno)
    {
        oxygen += _oxigeno;
    }

}
