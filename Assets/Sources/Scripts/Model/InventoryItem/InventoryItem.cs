using UnityEngine;
using UnityEngine.Events;

public abstract class InventoryItem : MonoBehaviour
{
    public int ItemsCount => _itemsCount;
    public int StackCount => GetStackCount();
    public DraggableItem DraggableItem => _draggableItem;

    public event UnityAction<int> ItemsCountChanged;
    public event UnityAction ItemDestroyed;

    [SerializeField] private DraggableItem _draggableItem;

    private int _itemsCount;

    public void FillStack()
    {
        _itemsCount = GetStackCount();
        ItemsCountChanged?.Invoke(_itemsCount);
    }

    public void TryIncreaseCount()
    {
        if (GetIncreaseCountCheckResult())
        {
            _itemsCount++;
            ItemsCountChanged?.Invoke(_itemsCount);
        }
    }

    public void TryDecreaseCount()
    {
        if (_itemsCount > 0)
        {
            _itemsCount--;
            ItemsCountChanged?.Invoke(_itemsCount);
            TryDestroyItem();
        }
    }

    private void TryDestroyItem()
    {
        if (_itemsCount == 0)
        {
            ItemDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }

    public abstract void InitializeItem();
    protected abstract bool GetIncreaseCountCheckResult();
    protected abstract int GetStackCount();
}
