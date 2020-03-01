using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;

    private float spawnRange = 9.0f;

    private int enemiesToSpawn;
    public int enemyCount;
    public int waveManager = 1;

//    public int powerUpsToSpawn = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveManager);
        Instantiate(powerupPrefab, GenerateSpawnPosition() + new Vector3(0, .7f, 0), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            SpawnEnemyWave(waveManager);
            Instantiate(powerupPrefab, GenerateSpawnPosition() + new Vector3(0, .7f, 0), powerupPrefab.transform.rotation); 
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
