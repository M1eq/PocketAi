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
    private JsonSaveSystem _jsonSaveSystem;

    public void Initialize()
    {
        InitializeHealth(_playerHealth);
        _playerHealthPresenter.Initialize(_loseMenu);
    }

    public void SavePlayerData()
    {
        _jsonSaveSystem.SaveData.PlayerHealth = _playerHealth.CurrentHealth;
        _jsonSaveSystem.SaveData.EquipedWeapon = _weaponEquiper.EquippedWeapon;
        _jsonSaveSystem.SaveData.EquipedBodyClothes = ClothesEquiper.BodyClothes;
        _jsonSaveSystem.SaveData.EquipedHeadClothes = ClothesEquiper.HeadClothes;

        _jsonSaveSystem.Save();
    }

    [Inject]
    private void Construct(Cell[] cells, ClothesEquiper clothesEquiper, Health playerHealth, LoseMenu loseMenu, JsonSaveSystem jsonSaveSystem)
    {
        _weaponEquiper.Initialize(cells);
        _clothesEquiper = clothesEquiper;
        _playerHealth = playerHealth;
        _loseMenu = loseMenu;
        _jsonSaveSystem = jsonSaveSystem;
    }
}
