using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] Transform pathPrefabs;
    [SerializeField] float enemyMoveSpeed = 5f;

    public Transform GetStaringWaypoint()
    {
        return pathPrefabs.GetChild(0).transform;
    }

    public float GetEnemyMoveSpeed()
    {
        return enemyMoveSpeed;
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoints = new Transform[pathPrefabs.childCount];
        for(int i = 0; i < pathPrefabs.childCount; i++)
        {
            waypoints[i] = pathPrefabs.GetChild(i);
        }
        
        return waypoints;
    }
}
