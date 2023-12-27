using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public GameObject player;
    public Transform startPoint;

    void Awake() 
    {
        StartGame();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartGame()
    {
        InstantiatePlayer();
    }
    
    private void InstantiatePlayer()
    {
        Instantiate(player, startPoint.position, startPoint.rotation);
    }
}
