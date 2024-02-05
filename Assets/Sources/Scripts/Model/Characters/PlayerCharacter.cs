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
    private Cell[] _inventoryCells;

    public void Initialize()
    {
        InitializeHealth(_playerHealth);
        _playerHealthPresenter.Initialize(_loseMenu);
    }

    public void SavePlayerData()
    {
        TrySavePlayerInventory();

        _jsonSaveSystem.SaveData.PlayerHealth = _playerHealth.CurrentHealth;
        _jsonSaveSystem.SaveData.EquipedWeaponAmmoType = _weaponEquiper.EquippedWeapon.AmmoType;

        if (_clothesEquiper.BodyClothes != null)
            _jsonSaveSystem.SaveData.EquipedBodyClothesId = _clothesEquiper.BodyClothes.ItemID;

        if (_clothesEquiper.HeadClothes != null)
            _jsonSaveSystem.SaveData.EquipedHeadClothesId = _clothesEquiper.HeadClothes.ItemID;

        _jsonSaveSystem.Save();
    }

    private void TrySavePlayerInventory()
    {
        if (_inventoryCells != null)
        {
            _jsonSaveSystem.SaveData.ItemsId.Clear();
            _jsonSaveSystem.SaveData.InventoryItemsCount.Clear();

            for (int i = 0; i < _inventoryCells.Length; i++)
            {
                if (_inventoryCells[i].OccupiedItem != null)
                {
                    _jsonSaveSystem.SaveData.ItemsId.Add(_inventoryCells[i].OccupiedItem.ItemID);
                    _jsonSaveSystem.SaveData.InventoryItemsCount.Add(_inventoryCells[i].OccupiedItem.ItemsCount);
                }
            }
        }
    }

    [Inject]
    private void Construct(Cell[] cells, ClothesEquiper clothesEquiper, Health playerHealth, LoseMenu loseMenu, JsonSaveSystem jsonSaveSystem)
    {
        _inventoryCells = cells;
        _weaponEquiper.Initialize(_inventoryCells);
        _clothesEquiper = clothesEquiper;
        _playerHealth = playerHealth;
        _loseMenu = loseMenu;
        _jsonSaveSystem = jsonSaveSystem;
    }
}
