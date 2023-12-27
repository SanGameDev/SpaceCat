using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolowPlayer : MonoBehaviour
{
    public Transform player;
    public float xOffSet;
    public float yOffSet;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x + xOffSet, player.position.y + yOffSet, -10f), 0.1f);
    }
}
