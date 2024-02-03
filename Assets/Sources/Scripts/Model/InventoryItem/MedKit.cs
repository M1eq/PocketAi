using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MedKit : InventoryItem
{
    public event UnityAction<MedKitParameters, Image> MedKitInitializing;

    [SerializeField] private MedKitParameters _medKitParameters;
    [SerializeField] private Image _medKitIcon;

    public override void InitializeItem() => MedKitInitializing?.Invoke(_medKitParameters, _medKitIcon);
    protected override bool GetIncreaseCountCheckResult() => ItemsCount + 1 <= _medKitParameters.CountInStack;
    protected override int GetStackCount() => _medKitParameters.CountInStack;

}
