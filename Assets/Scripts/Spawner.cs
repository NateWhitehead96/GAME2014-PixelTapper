/* Spawner
 * Nathan Whitehead
 * 101242269
 * 2020-10-19
 * Mobile Game Development GAME-2014
 * This script is for my custom spawner. It takes in all of the spawn points and potential patrons to randomize their
 * location and which patrons spawns. It also controls the game difficulty.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] patrons;
    public GameObject[] spawnPoints;

    public float spawnTimer = 0f; // our current time
    public float spawnSender = 5f; // how long to wait until sending new patron

    private int totalSpawned = 0; // int to keep track of # of spawned patrons

    public AudioSource spawnSound;

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer >= spawnSender) // time to spawn a patron
        {
            SpawnPatron();
            spawnTimer = 0;
            totalSpawned++;
        }
        else
        {
            spawnTimer += Time.deltaTime;
        }
        // Gradually increase speed of sender based on # of spawned and finally score
        if (totalSpawned == 10)
        {
            spawnSender = 3f;
        }
        if (totalSpawned == 20)
        {
            spawnSender = 1.5f;
        }
        if (totalSpawned == 30)
        {
            spawnSender = 1f;
        }
        if (ScoreManager.score == 50)
        {
            spawnSender = 0.75f;
        }
    }

    private void SpawnPatron()
    {
        // First randomizing spawn point to 1 of 4, then randomly choosing 1 of 2 patrons to send
        GameObject spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawnedObject = patrons[Random.Range(0, patrons.Length)];

        Instantiate(spawnedObject, spawnPos.transform.position, Quaternion.identity);
        spawnSound.Play();
    }
}
