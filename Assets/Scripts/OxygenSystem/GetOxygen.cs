using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOxygen : MonoBehaviour
{

    public OxygenSystem ox;

    void Start()
    {
        ox = GameObject.FindWithTag("Player").GetComponent<OxygenSystem>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Has obtenido oxigeno");
            other.gameObject.GetComponent<OxygenSystem>().darOxigeno(20);
            Destroy(gameObject);
        }
    }
}
