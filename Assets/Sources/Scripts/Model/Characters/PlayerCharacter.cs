using UnityEngine;
using Zenject;

public class PlayerCharacter : Character
{
    public WeaponEquiper WeaponEquiper => _weaponEquiper;
    public ClothesEquiper ClothesEquiper => _clothesEquiper;

    [SerializeField] private WeaponEquiper _weaponEquiper = new WeaponEquiper();
    [SerializeField] private PlayerHealthPresenter _playerHealthPresenter;

    private ClothesEquiper _clothesEquiper;
    private Health _playerHealth;
    private LoseMenu _loseMenu;

    public void Initialize()
    {
        InitializeHealth(_playerHealth);
        _playerHealthPresenter.Initialize(_loseMenu);
    }

    [Inject]
    private void Construct(Cell[] inventoryCells, ClothesEquiper clothesEquiper, Health playerHealth, LoseMenu loseMenu)
    {
        _weaponEquiper.Initialize(inventoryCells);
        _clothesEquiper = clothesEquiper;
        _playerHealth = playerHealth;
        _loseMenu = loseMenu;
    }
}
