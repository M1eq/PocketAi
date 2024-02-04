using UnityEngine;
using UnityEngine.UI;

public class HeadClothesPresenter : InventoryItemPresenter
{
    [SerializeField] private HeadClothes _headClothes;

    private HeadClothesParameters _headClothesParameters;

    protected override InventoryItem GetInventoryItem() => _headClothes;

    protected override void RemoveAllActionListeners()
    {
        _headClothes.ItemsCountChanged -= OnItemCountChanged;
        _headClothes.ItemDestroyed -= OnItemDestroyed;
        _headClothes.HeadClothesInitializing -= OnHeadClothesInitializing;
    }

    private void OnHeadClothesInitializing(HeadClothesParameters headClothesParameters, Image headClothesImage)
    {
        headClothesImage.sprite = headClothesParameters.ItemSprite;
        _headClothesParameters = headClothesParameters;
    }

    private void OnEnable()
    {
        _headClothes.ItemsCountChanged += OnItemCountChanged;
        _headClothes.ItemDestroyed += OnItemDestroyed;
        _headClothes.HeadClothesInitializing += OnHeadClothesInitializing;
    }

    private void OnDisable() => RemoveAllActionListeners();
}
