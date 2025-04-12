using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f; // Range for spawning enemies
    public int enemyCount;
    public int waveNumber = 1;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpawnEnemyWave(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; // Count the number of enemies in the scene

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber); // Spawn a new wave of enemies if there are none left
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
        float spawmPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawmPosX, 0, spawnPosZ);

        return randomPos;
    }
}
