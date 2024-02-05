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
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Image _protectionIcon;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _interactionButton;

    public void ShowClothesPanel(string itemTitle, string interactionTitle, Sprite itemSprite) => 
        Show(itemTitle, interactionTitle, itemSprite, true);
    public void ShowConsumablesPanel(string itemTitle, string interactionTitle, Sprite itemSprite) => 
        Show(itemTitle, interactionTitle, itemSprite, false);

    private void Show(string itemTitle, string interactionTitle, Sprite itemSprite, bool activateProtectionIcon)
    {
        _protectionIcon.gameObject.SetActive(activateProtectionIcon);
        _interactionButtonTitle.text = interactionTitle;
        _itemTitleText.text = itemTitle;
        _itemIcon.sprite = itemSprite;

        _itemPanel.gameObject.SetActive(true);
    }
}
