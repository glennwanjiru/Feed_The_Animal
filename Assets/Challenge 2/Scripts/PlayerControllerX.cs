using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    // Cooldown duration in seconds
    public float spawnCooldown = 1.5f;  // Set the cooldown to 1.5 seconds or any value you prefer
    private bool canSpawn = true;       // Track if the player can spawn another dog

    // Update is called once per frame
    void Update()
    {
        // Check if spacebar is pressed and player can spawn a dog
        if (Input.GetKeyDown(KeyCode.Space) && canSpawn)
        {
            // Spawn a dog
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            // Start the cooldown coroutine
            StartCoroutine(SpawnCooldown());
        }
    }

    // Coroutine to handle the cooldown between dog spawns
    IEnumerator SpawnCooldown()
    {
        canSpawn = false;  // Prevent spawning
        yield return new WaitForSeconds(spawnCooldown);  // Wait for the cooldown time to pass
        canSpawn = true;   // Allow spawning again
    }
}
