using UnityEngine;
using UnityEngine.UI;

public class MedKitItemPresenter : InventoryItemPresenter
{
    [SerializeField] private MedKit _medKit;
    [SerializeField] private Button _activationPanelButton;

    private InteractionPanelShower _interactionPanel;
    private MedKitParameters _medKitParameters;
    private Health _playerHealth;

    public void SetPlayerHealth(Health playerHealth) => _playerHealth = playerHealth;
    protected override InventoryItem GetInventoryItem() => _medKit;

    protected override void RemoveAllActionListeners()
    {
        _medKit.ItemsCountChanged -= OnItemCountChanged;
        _medKit.ItemDestroyed -= OnItemDestroyed;
        _medKit.MedKitInitializing -= OnMedKitInitializing;
        _activationPanelButton.onClick.RemoveAllListeners();

        if (_interactionPanel != null)
            ResetInteractionPanelListeners();
    }

    private void OnMedKitInitializing(MedKitParameters medKitParameters, Image medKitImage)
    {
        medKitImage.sprite = medKitParameters.ItemSprite;
        _medKitParameters = medKitParameters;

        _interactionPanel = GetInteractionPanel();
    }

    private void OnActivationPanelButtonPressed()
    {
        ResetInteractionPanelListeners();

        float weight = _medKitParameters.OneItemWeight * _medKit.ItemsCount;

        _interactionPanel.ShowConsumablesPanel(
            _medKitParameters.ItemTitle, _medKitParameters.ActionTitle, _medKitParameters.ItemSprite, weight);

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
        _interactionPanel.DeleteButton.onClick.AddListener(() => _medKit.TryDecreaseCount());
        _interactionPanel.DeleteButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void InitializeInteractionButton()
    {
        _interactionPanel.InteractionButton.onClick.AddListener(() => _medKit.TryDecreaseCount());
        _interactionPanel.InteractionButton.onClick.AddListener(() => _playerHealth.RestoreHP(_medKitParameters));
        _interactionPanel.InteractionButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        _medKit.ItemsCountChanged += OnItemCountChanged;
        _medKit.ItemDestroyed += OnItemDestroyed;
        _medKit.MedKitInitializing += OnMedKitInitializing;

        _activationPanelButton.onClick.AddListener(() => OnActivationPanelButtonPressed());
    }

    private void OnDisable() => RemoveAllActionListeners();
}
