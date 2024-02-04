using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Ammo : InventoryItem
{
    public AmmoType AmmoType => _ammoParameters.AmmoType;
    public event UnityAction<AmmoParameters, Image> AmmoInitializing;

    [SerializeField] private AmmoParameters _ammoParameters;
    [SerializeField] private Image _ammoIcon;

    public override void InitializeItem() => AmmoInitializing?.Invoke(_ammoParameters, _ammoIcon);
    protected override bool GetIncreaseCountCheckResult() => ItemsCount + 1 <= _ammoParameters.CountInStack;
    protected override int GetStackCount() => _ammoParameters.CountInStack;
}
