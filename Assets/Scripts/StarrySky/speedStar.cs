using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedStar : MonoBehaviour
{
    public float speed = 5.0f;
    public int damage = 10;
    public float lifeTime = 5.0f;


    private void Update()
    {
        Vector3 movement = Vector3.down * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDamage PlayerDamage = collision.gameObject.GetComponent<playerDamage>();
            if (PlayerDamage != null) 
            {
                PlayerDamage.TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
