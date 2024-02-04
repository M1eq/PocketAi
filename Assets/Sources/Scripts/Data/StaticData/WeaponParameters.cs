using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Parameters/Weapon")]
public class WeaponParameters : ScriptableObject
{
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int AmmoDecreaseStep { get; private set; }
    [field: SerializeField] public AmmoType AmmoType { get; private set; }
}
