using UnityEngine;

public class MoveEnemy1 : MonoBehaviour
{
    [SerializeField] Enemy1 enemy;
    [SerializeField] float enemySpeed = 5f;
    Transform[] getpointsWave;
    int pointIndex = 0;
    void Start()
    {
        getpointsWave = enemy.WavePoints();
    }

    // Update is called once per frame
    void Update()
    {
        PathWaves();
    }

    public void PathWaves()
    {
        Vector3 targetPositions = getpointsWave[pointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, targetPositions, enemySpeed * Time.deltaTime);
        if (transform.position == targetPositions) 
        {
            pointIndex++;
        }
        if (pointIndex >= getpointsWave.Length)
        {
            pointIndex = 0;
        }
    }
}
