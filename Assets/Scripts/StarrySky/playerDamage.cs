using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour
{
    public int health = 100;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Star"))
        {
            health -= 10;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player take " + damage + " points of damage. Now have  " + currentHealth + " of HP");
    }
}
