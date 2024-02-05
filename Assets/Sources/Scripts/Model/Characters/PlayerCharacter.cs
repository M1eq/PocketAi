using UnityEngine;
using Zenject;

public class PlayerCharacter : Character
{
    public WeaponEquiper WeaponEquiper => _weaponEquiper;
    public ClothesEquiper ClothesEquiper => _clothesEquiper;

    [SerializeField] private WeaponEquiper _weaponEquiper = new WeaponEquiper();

    private ClothesEquiper _clothesEquiper;

    [Inject]
    private void Construct(Cell[] inventoryCells, ClothesEquiper clothesEquiper)
    {
        _weaponEquiper.Initialize(inventoryCells);
        _clothesEquiper = clothesEquiper;
    }
}
