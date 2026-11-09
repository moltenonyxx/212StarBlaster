using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "Scriptable Objects/Enemy1")]
public class Enemy1 : ScriptableObject
{
    [SerializeField] Transform EnemyWave;

    public Transform[] WavePoints()
    {
        Transform[] WavePoints = new Transform[EnemyWave.childCount];
        for(int i =0; i <= EnemyWave.childCount ; i++)
        {
            WavePoints[i] = EnemyWave.GetChild(i);
        }
        return WavePoints;
    }
}
