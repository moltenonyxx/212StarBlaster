using NUnit.Framework.Constraints;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaves", menuName = "Scriptable Objects/EnemyWaves")]
public class EnemyWaves : ScriptableObject
{
    [SerializeField] Transform EnemyWave;

    public Transform[] EnemyPoints()
    {
        Transform[] EnemyPoint = new Transform[EnemyWave.childCount];
        for(int i =0; i <= EnemyWave.childCount ; i++)
        {
            EnemyPoint[i] = EnemyWave.GetChild(i).transform;
        }
        return EnemyPoint;
    }
}
