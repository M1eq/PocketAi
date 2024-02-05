using UnityEngine;
using UnityEngine.UI;

public abstract class Cell : MonoBehaviour
{
    public bool Occupied => GetOcupationCheckResult();
    public InventoryItem OccupiedItem => _occupiedItem; 

    [SerializeField] private Image _cellImage;

    private InventoryItem _occupiedItem; 

    public void Occupie(InventoryItem InventoryItem)
    {
        InventoryItem.DraggableItem.SetSnapParent(_cellImage.transform, this);
        InventoryItem.transform.parent = _cellImage.transform;
        InventoryItem.transform.localPosition = Vector3.zero;
        InventoryItem.transform.localScale = Vector3.one;

        _occupiedItem = InventoryItem;
    }

    public void ResetCell() => _occupiedItem = null;
    protected abstract bool GetOcupationCheckResult();
    protected InventoryItem GetOccupiedItem() => _occupiedItem;
}
