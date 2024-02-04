using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class WeaponEquiper
{
    public Weapon EquippedWeapon => _equippedWeapon;
    public event UnityAction WeaponEquipped;

    [SerializeField] private WeaponParameters _pistolWeaponParameters;
    [SerializeField] private WeaponParameters _automaticWeaponParameters;

    private Weapon _equippedWeapon;
    private Weapon _pistolWeapon;
    private Weapon _automaticWeapon;
    private Cell[] _inventoryCells;

    public void EquipPistol() => EquipWeapon(_pistolWeapon);
    public void EquipAutomaticWeapon() => EquipWeapon(_automaticWeapon);

    public void Initialize(Cell[] inventoryCells)
    {
        _inventoryCells = inventoryCells;
        TryInitializeWeapon();
    }

    private void EquipWeapon(Weapon weapon)
    {
        _equippedWeapon = weapon;
        WeaponEquipped?.Invoke();
    }

    private void TryInitializeWeapon()
    {
        if (_pistolWeapon == null || _automaticWeapon == null)
        {
            _pistolWeapon = new Weapon(_pistolWeaponParameters, _inventoryCells);
            _automaticWeapon = new Weapon(_automaticWeaponParameters, _inventoryCells);
        }
    }
}
