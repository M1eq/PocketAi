using UnityEngine;
using UnityEngine.UI;

public class BodyClothesItemPresenter : InventoryItemPresenter
{
    [SerializeField] private BodyClothes bodyClothes;

    private BodyClothesParameters _bodyClothesParameters;

    protected override void RemoveAllActionListeners()
    {
        bodyClothes.ItemsCountChanged -= OnItemCountChanged;
        bodyClothes.ItemDestroyed -= OnItemDestroyed;
        bodyClothes.BodyClothesInitializing -= OnBodyClothesInitializing;
    }

    private void OnBodyClothesInitializing(BodyClothesParameters bodyClothesParameters, Image bodyClothesImage)
    {
        bodyClothesImage.sprite = bodyClothesParameters.ItemSprite;
        _bodyClothesParameters = bodyClothesParameters;
    }

    private void OnEnable()
    {
        bodyClothes.ItemsCountChanged += OnItemCountChanged;
        bodyClothes.ItemDestroyed += OnItemDestroyed;
        bodyClothes.BodyClothesInitializing += OnBodyClothesInitializing;
    }

    private void OnDisable() => RemoveAllActionListeners();
}
