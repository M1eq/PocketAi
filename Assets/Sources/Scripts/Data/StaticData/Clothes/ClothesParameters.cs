using UnityEngine;

public abstract class ClothesParameters : ItemParameters
{
    [field: SerializeField] public float ProtectionScoreCount { get; private set; }
}
