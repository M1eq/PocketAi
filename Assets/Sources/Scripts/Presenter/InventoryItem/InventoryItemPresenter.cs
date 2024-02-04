using UnityEngine;

public abstract class InventoryItemPresenter : MonoBehaviour
{
    public InventoryItem InventoryItem => GetInventoryItem();

    [SerializeField] private ItemCountShower _itemCountShower;
    [SerializeField] private DraggableItem _draggableItem;

    private InteractionPanelShower _interactionPanelShower;

    public void Initialize(InteractionPanelShower interactionPanelShower, Canvas inventoryCanvas)
    {
        _interactionPanelShower = interactionPanelShower;
        _draggableItem.Initialize(inventoryCanvas);
    }

    protected void OnItemCountChanged(int itemCount) => _itemCountShower.TryShowItemCount(itemCount);
    protected InteractionPanelShower GetInteractionPanel() => _interactionPanelShower;
    protected void OnItemDestroyed() => RemoveAllActionListeners();
    protected abstract void RemoveAllActionListeners();
    protected abstract InventoryItem GetInventoryItem();
}
