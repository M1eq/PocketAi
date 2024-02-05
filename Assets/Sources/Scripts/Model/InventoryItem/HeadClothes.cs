using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HeadClothes : InventoryItem
{
    public int Protection => _headClothesParameters.ProtectionScoreCount;
    public event UnityAction<HeadClothesParameters, Image> HeadClothesInitializing;

    [SerializeField] private HeadClothesParameters _headClothesParameters;
    [SerializeField] private Image _headClothesIcon;

    public override void InitializeItem() => HeadClothesInitializing?.Invoke(_headClothesParameters, _headClothesIcon);
    protected override bool GetIncreaseCountCheckResult() => ItemsCount + 1 <= _headClothesParameters.CountInStack;
    protected override int GetStackCount() => _headClothesParameters.CountInStack;
}
