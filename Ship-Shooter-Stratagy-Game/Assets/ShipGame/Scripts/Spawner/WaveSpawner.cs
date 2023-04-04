using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    private Wave currentWave;
    
    public Transform[] bossSpawnPoints;
    [SerializeField] private Transform[] spawnPoints;

    private float timeBtwSpawns;
    public int currentWaveIndex = 0;

    private bool stopSpawning = false;

    
    private void Awake()
    {
        
        currentWave = waves[currentWaveIndex];
        timeBtwSpawns = currentWave.timeBeforeThisWave;
    }
    private void Update()
    {
      
        if (stopSpawning)
            return;

        if (Time.time >= timeBtwSpawns)
        {
            SpawnWave();
            IncWave();

            timeBtwSpawns = Time.time + currentWave.timeBeforeThisWave;
        }

    }

    private void SpawnWave()
    {
        for (int i = 0; i < currentWave.numberToSpawn; i++)
        {
            int randEnemy = UnityEngine.Random.Range(0, currentWave.enimiesInWave.Length);
            int randSpawnPoint = UnityEngine.Random.Range(0, spawnPoints.Length);

            Instantiate(currentWave.enimiesInWave[randEnemy], spawnPoints[randSpawnPoint].position, Quaternion.identity);

        }
    }
    private void IncWave()
    {
        if (currentWaveIndex + 1 < waves.Length)
        {
            currentWaveIndex++;
            currentWave = waves[currentWaveIndex];

            if (currentWaveIndex == waves.Length)
            {
                Debug.Log("Boss Coming ....");
            }
           
        }
        else
        {
            stopSpawning = true;
            
        }
    }
    
}
