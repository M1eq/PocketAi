using UnityEngine;
using UnityEngine.UI;

public class AmmoItemPresenter : InventoryItemPresenter
{
    [SerializeField] private Ammo _ammo;
    [SerializeField] private Button _activationPanelButton;

    private InteractionPanelShower _interactionPanel;
    private AmmoParameters _ammoParameters;

    protected override InventoryItem GetInventoryItem() => _ammo;

    protected override void RemoveAllActionListeners()
    {
        _ammo.ItemsCountChanged -= OnItemCountChanged;
        _ammo.ItemDestroyed -= OnItemDestroyed;
        _ammo.AmmoInitializing -= OnAmmoInitializing;
        _activationPanelButton.onClick.RemoveAllListeners();

        if (_interactionPanel != null)
            ResetInteractionPanelListeners();
    }

    private void OnAmmoInitializing(AmmoParameters ammoParameters, Image ammoImage)
    {
        ammoImage.sprite = ammoParameters.ItemSprite;
        _ammoParameters = ammoParameters;

        _interactionPanel = GetInteractionPanel();
    }

    private void OnActivationPanelButtonPressed()
    {
        ResetInteractionPanelListeners();

        float weight = _ammoParameters.OneItemWeight * _ammo.ItemsCount;

        _interactionPanel.ShowConsumablesPanel(
            _ammoParameters.ItemTitle, _ammoParameters.ActionTitle, _ammoParameters.ItemSprite, weight);

        InitializeDeleteButton();
        InitializeInteractionButton();
    }

    private void ResetInteractionPanelListeners()
    {
        _interactionPanel.DeleteButton.onClick.RemoveAllListeners();
        _interactionPanel.InteractionButton.onClick.RemoveAllListeners();
    }

    private void InitializeDeleteButton()
    {
        _interactionPanel.DeleteButton.onClick.AddListener(() => _ammo.TryDecreaseCount());
        _interactionPanel.DeleteButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void InitializeInteractionButton()
    {
        _interactionPanel.InteractionButton.onClick.AddListener(() => _ammo.FillStack());
        _interactionPanel.InteractionButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        _ammo.ItemsCountChanged += OnItemCountChanged;
        _ammo.ItemDestroyed += OnItemDestroyed;
        _ammo.AmmoInitializing += OnAmmoInitializing;

        _activationPanelButton.onClick.AddListener(() => OnActivationPanelButtonPressed());
    }

    private void OnDisable() => RemoveAllActionListeners();
}
