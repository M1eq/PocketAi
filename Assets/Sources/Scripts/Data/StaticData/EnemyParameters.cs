using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Parameters/Enemy")]
public class EnemyParameters : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
}
