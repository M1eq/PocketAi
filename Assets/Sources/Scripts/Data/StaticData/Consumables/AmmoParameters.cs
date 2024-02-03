using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Parameters/Ammo")]
public class AmmoParameters : ItemParameters
{
    [field: SerializeField] public int OneAmmoPrice { get; private set; }
}
