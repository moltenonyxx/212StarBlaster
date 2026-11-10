using UnityEngine;

[CreateAssetMenu(fileName = "Waves", menuName = "New WaveSO")]
public class WaveSO : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float enemySpeed = 5f;

    public Transform GetStaringWaypoint()
    {
        return pathPrefab.GetChild(0).transform;
    }

    public float GetEnemySpeed()
    {
        return enemySpeed;
    }

    public Transform[] GetWaypoints()
    {
        Transform[] waypoints = new Transform[pathPrefab.childCount];
        for (int i = 0; i < pathPrefab.childCount; i++)
        {
            waypoints[i] = pathPrefab.GetChild(i);
        }

        return waypoints;
    }
}
