using UnityEngine;
using UnityEngine.UI;

public class AmmoItemPresenter : InventoryItemPresenter
{
    [SerializeField] private Ammo _ammo;

    private AmmoParameters _ammoParameters;

    protected override void RemoveAllActionListeners()
    {
        _ammo.ItemsCountChanged -= OnItemCountChanged;
        _ammo.ItemDestroyed -= OnItemDestroyed;
        _ammo.AmmoInitializing -= OnAmmoInitializing;
    }

    private void OnAmmoInitializing(AmmoParameters ammoParameters, Image ammoImage)
    {
        ammoImage.sprite = ammoParameters.ItemSprite;
        _ammoParameters = ammoParameters;
    }

    private void OnEnable()
    {
        _ammo.ItemsCountChanged += OnItemCountChanged;
        _ammo.ItemDestroyed += OnItemDestroyed;
        _ammo.AmmoInitializing += OnAmmoInitializing;
    }

    private void OnDisable() => RemoveAllActionListeners();
}
