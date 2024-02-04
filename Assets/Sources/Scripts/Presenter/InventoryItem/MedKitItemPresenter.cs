using UnityEngine;
using UnityEngine.UI;

public class MedKitItemPresenter : InventoryItemPresenter
{
    [SerializeField] private MedKit _medKit;

    private MedKitParameters _medKitParameters;

    protected override InventoryItem GetInventoryItem() => _medKit;

    protected override void RemoveAllActionListeners()
    {
        _medKit.ItemsCountChanged -= OnItemCountChanged;
        _medKit.ItemDestroyed -= OnItemDestroyed;
        _medKit.MedKitInitializing -= OnMedKitInitializing;
    }

    private void OnMedKitInitializing(MedKitParameters medKitParameters, Image medKitImage)
    {
        medKitImage.sprite = medKitParameters.ItemSprite;
        _medKitParameters = medKitParameters;
    }

    private void OnEnable()
    {
        _medKit.ItemsCountChanged += OnItemCountChanged;
        _medKit.ItemDestroyed += OnItemDestroyed;
        _medKit.MedKitInitializing += OnMedKitInitializing;
    }

    private void OnDisable() => RemoveAllActionListeners();
}
