using UnityEngine;

[CreateAssetMenu(fileName = "Clothes", menuName = "Parameters/Clothes")]
public class ClothesParameters : ItemParameters
{
    [field: SerializeField] public float ProtectionScoreCount { get; private set; }
}
