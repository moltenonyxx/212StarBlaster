using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;
    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount() ; i++)
        {
            Instantiate
            (   
                currentWave.GetEnemyPrefab(i),
                currentWave.GetStaringWaypoint().position,
                Quaternion.identity, //tells it no rotation
                transform
            );
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
