using UnityEngine;

public enum AmmoType
{
    pistolAmmo, automaticWeaponAmmo
}

[CreateAssetMenu(fileName = "Ammo", menuName = "Parameters/Ammo")]
public class AmmoParameters : ItemParameters
{
    [field: Space(10), SerializeField] public AmmoType AmmoType { get; private set; }
}
