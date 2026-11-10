using UnityEngine;

public class WavePathfinding : MonoBehaviour
{
    [SerializeField] WaveSO wave;
    Transform[] waypoints;
    int waypointIndex = 0;
    void Start()
    {
        waypoints = wave.GetWaypoints();
        transform.position = wave.GetStaringWaypoint().position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveDelta = wave.GetEnemySpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
