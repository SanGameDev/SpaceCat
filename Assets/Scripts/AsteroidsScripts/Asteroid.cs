using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            collision.GetComponent<PlayerMovement>().OnAsteroid(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Contains("Player"))
        {
            collision.GetComponent<PlayerMovement>().OutAsteroid();
        }
    }

}
