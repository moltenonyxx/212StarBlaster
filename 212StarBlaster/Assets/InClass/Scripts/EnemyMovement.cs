using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Enemy1 enemy;
    [SerializeField] float enemySpeed = 5f;
    Transform[] getpointsWave;
    int pointIndex = 0;
    void Start()
    {
        getpointsWave = enemy.WavePoints();
    }

    void Update()
    {
        PathWaves();
    }
    
    void PathWaves()
    {
        Vector3 targetPositions = getpointsWave[pointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPositions, enemySpeed);
        if(transform.position == targetPositions)
        {
            pointIndex++;
        }
        if (pointIndex >= getpointsWave.Length)
        {
            pointIndex = 0;
        }
    }
}
