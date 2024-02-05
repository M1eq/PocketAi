using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Parameters/Player")]
public class PlayerParameters : ScriptableObject
{
    [field: SerializeField] public int MaxHealth { get; private set; }
}
