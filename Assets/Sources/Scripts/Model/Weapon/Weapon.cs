using UnityEngine.Events;

public class Weapon
{
    public event UnityAction AmmoInserted;
    public event UnityAction AmmoInsertBreaked;

    private WeaponParameters _weaponParameters;
    private Cell[] _inventoryCells;
    private Ammo _equippedAmmo;
    private bool _ammoInserted;

    public Weapon(WeaponParameters weaponParameters, Cell[] inventoryCell)
    {
        _weaponParameters = weaponParameters;
        _inventoryCells = inventoryCell;
    }

    public int GetShootDamage()
    {
        for (int i = 0; i < _weaponParameters.AmmoDecreaseStep; i++)
            _equippedAmmo.TryDecreaseCount();

        return _weaponParameters.Damage;
    }

    public void TryInsertAmmo()
    {
        _ammoInserted = false;

        for (int i = 0; i < _inventoryCells.Length; i++)
        {
            if (_inventoryCells[i].Occupied == true)
            {
                if (_inventoryCells[i].OccupiedItem.TryGetComponent<Ammo>(out Ammo ammo))
                {
                    if (ammo.AmmoType == _weaponParameters.AmmoType)
                    {
                        if (ammo.ItemsCount >= _weaponParameters.AmmoDecreaseStep)
                        {
                            _equippedAmmo = ammo;
                            AmmoInserted?.Invoke();
                            _ammoInserted = true;
                        }
                    }
                }
            }
        }

        if (_ammoInserted == false)
            AmmoInsertBreaked?.Invoke();
    }
}
