using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] patrons;
    public GameObject[] spawnPoints;

    public float spawnTimer;

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0) // time to spawn a patron
        {
            SpawnPatron();
            spawnTimer = 10;
        }
    }

    private void SpawnPatron()
    {
        GameObject spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject spawnedObject = patrons[Random.Range(0, patrons.Length)];

        Instantiate(spawnedObject, spawnPos.transform.position, Quaternion.identity);
    }
}
