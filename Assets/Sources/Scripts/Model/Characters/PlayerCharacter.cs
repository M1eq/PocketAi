using UnityEngine;
using Zenject;

public class PlayerCharacter : Character
{
    public WeaponEquiper WeaponEquiper => _weaponEquiper;

    [SerializeField] private WeaponEquiper _weaponEquiper = new WeaponEquiper();

    [Inject]
    private void Construct(Cell[] inventoryCells) => _weaponEquiper.Initialize(inventoryCells);
}
