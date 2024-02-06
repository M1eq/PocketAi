using UnityEngine;
using UnityEngine.UI;

public class BodyClothesItemPresenter : InventoryItemPresenter
{
    [SerializeField] private BodyClothes _bodyClothes;
    [SerializeField] private Button _activationPanelButton;

    private BodyClothesParameters _bodyClothesParameters;
    private InteractionPanelShower _interactionPanel;
    private ClothesEquiper _clothesEquiper;

    public void SetClothesEquiper(ClothesEquiper clothesEquiper) => _clothesEquiper = clothesEquiper;
    protected override InventoryItem GetInventoryItem() => _bodyClothes;

    protected override void RemoveAllActionListeners()
    {
        _bodyClothes.ItemsCountChanged -= OnItemCountChanged;
        _bodyClothes.ItemDestroyed -= OnItemDestroyed;
        _bodyClothes.BodyClothesInitializing -= OnBodyClothesInitializing;

        if (_interactionPanel != null)
            ResetInteractionPanelListeners();
    }

    private void OnBodyClothesInitializing(BodyClothesParameters bodyClothesParameters, Image bodyClothesImage)
    {
        bodyClothesImage.sprite = bodyClothesParameters.ItemSprite;
        _bodyClothesParameters = bodyClothesParameters;

        _interactionPanel = GetInteractionPanel();
    }

    private void OnActivationPanelButtonPressed()
    {
        ResetInteractionPanelListeners();

        float weight = _bodyClothesParameters.OneItemWeight * _bodyClothes.ItemsCount;

        _interactionPanel.ShowClothesPanel(_bodyClothesParameters.ItemTitle, _bodyClothesParameters.ActionTitle,
            _bodyClothesParameters.ItemSprite, weight, _bodyClothesParameters.ProtectionScoreCount);

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
        _interactionPanel.DeleteButton.onClick.AddListener(() => _bodyClothes.TryDecreaseCount());
        _interactionPanel.DeleteButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void InitializeInteractionButton()
    {
        _interactionPanel.InteractionButton.onClick.AddListener(() => _clothesEquiper.EquipBodyClothes(_bodyClothes));
        _interactionPanel.InteractionButton.onClick.AddListener(() => _interactionPanel.gameObject.SetActive(false));
    }

    private void OnEnable()
    {
        _bodyClothes.ItemsCountChanged += OnItemCountChanged;
        _bodyClothes.ItemDestroyed += OnItemDestroyed;
        _bodyClothes.BodyClothesInitializing += OnBodyClothesInitializing;

        _activationPanelButton.onClick.AddListener(() => OnActivationPanelButtonPressed());
    }

    private void OnDisable() => RemoveAllActionListeners();
}
