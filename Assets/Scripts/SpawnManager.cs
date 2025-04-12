using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f; // Range for spawning enemies

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       SpawnEnemyWave(3);
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
