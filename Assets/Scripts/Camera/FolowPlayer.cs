using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPlayer : MonoBehaviour
{
    public Transform player;
    public float xOffSet = 5f;
    public float yOffSet = 3f;
    public float speed = 0.3f;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    void FixedUpdate()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.x = Mathf.Clamp(mousePosition.x, player.position.x, player.position.x + xOffSet);
        mousePosition.y = Mathf.Clamp(mousePosition.y, player.position.y, player.position.y + yOffSet);
        
        //make a dead zone for the camera in the middle of the screen
        if (mousePosition.x < player.position.x + 1f && mousePosition.x > player.position.x - 1f)
        {
            mousePosition.x = player.position.x;
        }
        if (mousePosition.y < player.position.y + 1f && mousePosition.y > player.position.y - 1f)
        {
            mousePosition.y = player.position.y;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(mousePosition.x, mousePosition.y, -10f), speed);
    }
}
