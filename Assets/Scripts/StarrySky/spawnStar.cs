using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnStar : MonoBehaviour
{
    public GameObject StarPrefab;
    public float spawnInterval = 2.0f;
    public int maxStars = 1000;
    public float spawnHeight = 10.0f;
    public float spawnRadius = 5.0f;
    public float areaAngle = 45.0f;
    
    public Transform Player;


    private int currentStars = 0;
    private float nextSpawnTime = 0;

    private void Update()
    {
        if (currentStars < maxStars && Time.time > nextSpawnTime) 
        {
            Vector3 spawnPosition = CalculateRandomSpawnPositionAbovePlayer();
            Quaternion spawnRotation = Quaternion.Euler(0, 0, Random.Range(0, 300));
            GameObject newStar = Instantiate(StarPrefab, spawnPosition, spawnRotation);
            newStar.transform.rotation = Quaternion.Euler(0, 0, areaAngle);

            nextSpawnTime = Time.time + spawnInterval;
            currentStars++;
        }
    }

    private Vector3 CalculateRandomSpawnPositionAbovePlayer() 
    {
        Vector3 playerPosition = Player.position;

        float randomX = Random.Range(playerPosition.x - spawnRadius, playerPosition.x + spawnRadius * 5);
        Vector3 spawnPosition = new Vector3(randomX, playerPosition.y + spawnHeight, 0f);
        return spawnPosition;
    }
}
