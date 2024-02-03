using UnityEngine;

public abstract class InventoryItemPresenter : MonoBehaviour
{
    [SerializeField] private ItemCountShower _itemCountShower;

    protected void OnItemCountChanged(int itemCount) => _itemCountShower.TryShowItemCount(itemCount);
    protected void OnItemDestroyed() => RemoveAllActionListeners();
    protected abstract void RemoveAllActionListeners();
}
