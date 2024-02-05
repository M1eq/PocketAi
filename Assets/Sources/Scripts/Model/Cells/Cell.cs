using UnityEngine;
using UnityEngine.UI;

public abstract class Cell : MonoBehaviour
{
    public bool Occupied => GetOcupationCheckResult();
    public InventoryItem OccupiedItem => _occupiedItem; 

    [SerializeField] private Image _cellImage;

    private InventoryItem _occupiedItem; 

    public void Occupie(InventoryItem inventoryItem)
    {
        inventoryItem.DraggableItem.SetSnapParent(_cellImage.transform, this);
        inventoryItem.transform.parent = _cellImage.transform;
        inventoryItem.transform.localPosition = Vector3.zero;
        inventoryItem.transform.localScale = Vector3.one;

        _occupiedItem = inventoryItem;
    }

    public void ResetCell() => _occupiedItem = null;
    protected abstract bool GetOcupationCheckResult();
    protected InventoryItem GetOccupiedItem() => _occupiedItem;
}
