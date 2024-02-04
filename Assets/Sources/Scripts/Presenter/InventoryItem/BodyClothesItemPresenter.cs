using UnityEngine;
using UnityEngine.UI;

public class BodyClothesItemPresenter : InventoryItemPresenter
{
    [SerializeField] private BodyClothes _bodyClothes;

    private BodyClothesParameters _bodyClothesParameters;

    protected override InventoryItem GetInventoryItem() => _bodyClothes;

    protected override void RemoveAllActionListeners()
    {
        _bodyClothes.ItemsCountChanged -= OnItemCountChanged;
        _bodyClothes.ItemDestroyed -= OnItemDestroyed;
        _bodyClothes.BodyClothesInitializing -= OnBodyClothesInitializing;
    }

    private void OnBodyClothesInitializing(BodyClothesParameters bodyClothesParameters, Image bodyClothesImage)
    {
        bodyClothesImage.sprite = bodyClothesParameters.ItemSprite;
        _bodyClothesParameters = bodyClothesParameters;
    }

    private void OnEnable()
    {
        _bodyClothes.ItemsCountChanged += OnItemCountChanged;
        _bodyClothes.ItemDestroyed += OnItemDestroyed;
        _bodyClothes.BodyClothesInitializing += OnBodyClothesInitializing;
    }

    private void OnDisable() => RemoveAllActionListeners();
}
