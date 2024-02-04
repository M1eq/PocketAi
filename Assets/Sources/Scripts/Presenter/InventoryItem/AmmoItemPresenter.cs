using UnityEngine;
using UnityEngine.UI;

public class AmmoItemPresenter : InventoryItemPresenter
{
    [SerializeField] private Ammo _ammo;
    [SerializeField] private Button _ineractionPanelButton;
    [SerializeField] private InteractionPanelShower _interactionPanelShower;

    private AmmoParameters _ammoParameters;

    protected override void RemoveAllActionListeners()
    {
        _ammo.ItemsCountChanged -= OnItemCountChanged;
        _ammo.ItemDestroyed -= OnItemDestroyed;
        _ammo.AmmoInitializing -= OnAmmoInitializing;

        _ineractionPanelButton.onClick.RemoveAllListeners();
        _interactionPanelShower.DeleteButton.onClick.RemoveAllListeners();
    }

    private void OnAmmoInitializing(AmmoParameters ammoParameters, Image ammoImage)
    {
        ammoImage.sprite = ammoParameters.ItemSprite;
        _ammoParameters = ammoParameters;
    }

    private void OnInteractionPanelButtonPressed()
    {
        _interactionPanelShower.DeleteButton.onClick.RemoveAllListeners();

        _interactionPanelShower.ShowConsumablesPanel(
            _ammoParameters.ItemTitle, _ammoParameters.ActionTitle, _ammoParameters.ItemSprite);

        _interactionPanelShower.DeleteButton.onClick.AddListener(() => _ammo.TryDecreaseCount());
        _interactionPanelShower.DeleteButton.onClick.AddListener(() => _interactionPanelShower.gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        _ammo.ItemsCountChanged += OnItemCountChanged;
        _ammo.ItemDestroyed += OnItemDestroyed;
        _ammo.AmmoInitializing += OnAmmoInitializing;

        _ineractionPanelButton.onClick.AddListener(() => OnInteractionPanelButtonPressed());
    }

    private void OnDisable() => RemoveAllActionListeners();
}
