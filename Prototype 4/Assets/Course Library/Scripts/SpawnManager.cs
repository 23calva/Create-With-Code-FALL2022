using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int spawnRange = 8;

    public int waveNumber = 1;

    private void Start()
    {
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
    }

    private void Update()
    {
        var enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber++);
        }
    }

    private void SpawnEnemyWave(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector3 randomPos = Vector3.zero;
        randomPos.x = Random.Range(-spawnRange, spawnRange);
        randomPos.z = Random.Range(-spawnRange, spawnRange);
        return randomPos;
    }
}