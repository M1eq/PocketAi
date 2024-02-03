using UnityEngine;
using UnityEngine.UI;

public class HeadClothesPresenter : InventoryItemPresenter
{
    [SerializeField] private HeadClothes headClothes;

    private HeadClothesParameters _headClothesParameters;

    protected override void RemoveAllActionListeners()
    {
        headClothes.ItemsCountChanged -= OnItemCountChanged;
        headClothes.ItemDestroyed -= OnItemDestroyed;
        headClothes.HeadClothesInitializing -= OnHeadClothesInitializing;
    }

    private void OnHeadClothesInitializing(HeadClothesParameters headClothesParameters, Image headClothesImage)
    {
        headClothesImage.sprite = headClothesParameters.ItemSprite;
        _headClothesParameters = headClothesParameters;
    }

    private void OnEnable()
    {
        headClothes.ItemsCountChanged += OnItemCountChanged;
        headClothes.ItemDestroyed += OnItemDestroyed;
        headClothes.HeadClothesInitializing += OnHeadClothesInitializing;
    }

    private void OnDisable() => RemoveAllActionListeners();
}
