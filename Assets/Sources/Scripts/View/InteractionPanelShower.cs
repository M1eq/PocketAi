using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionPanelShower : MonoBehaviour
{
    public Button DeleteButton => _deleteButton;
    public Button InteractionButton => _interactionButton;

    [SerializeField] private GameObject _itemPanel;
    [SerializeField] private TMP_Text _itemTitleText;
    [SerializeField] private TMP_Text _interactionButtonTitle;
    [SerializeField] private TMP_Text _protectionCountText;
    [SerializeField] private TMP_Text _weightText;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Image _protectionIcon;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _interactionButton;

    public void ShowClothesPanel(string itemTitle, string interactionTitle, Sprite itemSprite, float weight, int protection)
    {
        ShowPanel(itemTitle, interactionTitle, itemSprite, true, weight);
        ShowProtection(protection);
    }

    public void ShowConsumablesPanel(string itemTitle, string interactionTitle, Sprite itemSprite, float weight)
    {
        ShowPanel(itemTitle, interactionTitle, itemSprite, false, weight);
    }

    private void ShowPanel(string itemTitle, string interactionTitle, Sprite itemSprite, bool activateProtectionIcon, float weight)
    {
        _protectionIcon.gameObject.SetActive(activateProtectionIcon);
        _interactionButtonTitle.text = interactionTitle;
        _weightText.text = weight.ToString();
        _itemTitleText.text = itemTitle;
        _itemIcon.sprite = itemSprite;

        _itemPanel.SetActive(true);
    }

    private void ShowProtection(int protection) => _protectionCountText.text = protection.ToString();
}
