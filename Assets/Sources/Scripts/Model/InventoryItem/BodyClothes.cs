using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BodyClothes : InventoryItem
{
    public int Protection => _bodyClothesParameters.ProtectionScoreCount;
    public event UnityAction<BodyClothesParameters, Image> BodyClothesInitializing;

    [SerializeField] private BodyClothesParameters _bodyClothesParameters;
    [SerializeField] private Image _bodyClothesIcon;

    public override void InitializeItem() => BodyClothesInitializing?.Invoke(_bodyClothesParameters, _bodyClothesIcon);
    protected override bool GetIncreaseCountCheckResult() => ItemsCount + 1 <= _bodyClothesParameters.CountInStack;
    protected override int GetStackCount() => _bodyClothesParameters.CountInStack;
    protected override string GetItemId() => _bodyClothesParameters.Id;
}
