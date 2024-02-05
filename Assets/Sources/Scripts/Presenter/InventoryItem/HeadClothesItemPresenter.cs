using UnityEngine;
using UnityEngine.UI;

public class HeadClothesItemPresenter : InventoryItemPresenter
{
    [SerializeField] private HeadClothes _headClothes;
    [SerializeField] private Button _activationPanelButton;

    private HeadClothesParameters _headClothesParameters;
    private InteractionPanelShower _interactionPanel;
    private ClothesEquiper _clothesEquiper;

    public void SetClothesEquiper(ClothesEquiper clothesEquiper) => _clothesEquiper = clothesEquiper;
    protected override InventoryItem GetInventoryItem() => _headClothes;

    protected override void RemoveAllActionListeners()
    {
        _headClothes.ItemsCountChanged -= OnItemCountChanged;
        _headClothes.ItemDestroyed -= OnItemDestroyed;
        _headClothes.HeadClothesInitializing -= OnHeadClothesInitializing;

        if (_interactionPanel != null)
            ResetInteractionPanelListeners();
    }

    private void OnHeadClothesInitializing(HeadClothesParameters headClothesParameters, Image headClothesImage)
    {
        headClothesImage.sprite = headClothesParameters.ItemSprite;
        _headClothesParameters = headClothesParameters;

        _interactionPanel = GetInteractionPanel();
    }

    private void OnActivationPanelButtonPressed()
    {
        ResetInteractionPanelListeners();

        _interactionPanel.ShowClothesPanel(
            _headClothesParameters.ItemTitle, _headClothesParameters.ActionTitle, _headClothesParameters.ItemSprite);

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
        _interactionPanel.DeleteButton.onClick.AddListener(() => _headClothes.TryDecreaseCount());
        _interactionPanel.DeleteButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void InitializeInteractionButton()
    {
        _interactionPanel.InteractionButton.onClick.AddListener(() => _clothesEquiper.EquipHeadClothes(_headClothes));
        _interactionPanel.InteractionButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        _headClothes.ItemsCountChanged += OnItemCountChanged;
        _headClothes.ItemDestroyed += OnItemDestroyed;
        _headClothes.HeadClothesInitializing += OnHeadClothesInitializing;

        _activationPanelButton.onClick.AddListener(() => OnActivationPanelButtonPressed());
    }

    private void OnDisable() => RemoveAllActionListeners();
}
