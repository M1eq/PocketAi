using UnityEngine;
using Zenject;

public class PlayerCharacter : Character
{
    public WeaponEquiper WeaponEquiper => _weaponEquiper;
    public ClothesEquiper ClothesEquiper => _clothesEquiper;

    [SerializeField] private WeaponEquiper _weaponEquiper = new WeaponEquiper();

    private ClothesEquiper _clothesEquiper;
    private Health _playerHealth;

    public void Initialize() => InitializeHealth(_playerHealth);

    [Inject]
    private void Construct(Cell[] inventoryCells, ClothesEquiper clothesEquiper, Health playerHealth)
    {
        _weaponEquiper.Initialize(inventoryCells);
        _clothesEquiper = clothesEquiper;
        _playerHealth = playerHealth;
    }
}
