using UnityEngine;

public abstract class ClothesParameters : ItemParameters
{
    [field: SerializeField] public int ProtectionScoreCount { get; private set; }
}
