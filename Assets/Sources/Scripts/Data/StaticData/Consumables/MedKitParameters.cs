using UnityEngine;

[CreateAssetMenu(fileName = "MedKit", menuName = "Parameters/MedKit")]
public class MedKitParameters : ItemParameters
{
    [field: SerializeField] public int RestoreHealthCount { get; private set; }
}
