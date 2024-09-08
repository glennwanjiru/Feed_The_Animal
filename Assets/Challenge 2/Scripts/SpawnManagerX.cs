using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    public float spawnLimitXLeft = -22;
    public float spawnLimitXRight = 7;
    public float spawnPosY = 30;

    public float startDelay = 1.0f;
    public float minSpawnInterval = 1.0f;  // Minimum time between spawns
    public float maxSpawnInterval = 5.0f;  // Maximum time between spawns

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBallWithRandomInterval());
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Randomly select a ball prefab to spawn
        int ballIndex = Random.Range(0, ballPrefabs.Length);

        // Instantiate ball at random spawn location
        Instantiate(ballPrefabs[ballIndex], spawnPos, ballPrefabs[ballIndex].transform.rotation);
    }

    // Coroutine to spawn balls at random intervals
    IEnumerator SpawnRandomBallWithRandomInterval()
    {
        // Initial delay before spawning starts
        yield return new WaitForSeconds(startDelay);

        while (true)
        {
            // Spawn a random ball
            SpawnRandomBall();

            // Wait for a random interval before spawning the next ball
            float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(randomInterval);
        }
    }
}
