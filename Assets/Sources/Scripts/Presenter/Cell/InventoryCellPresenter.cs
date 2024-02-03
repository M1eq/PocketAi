using UnityEngine;

public class InventoryCellPresenter : CellPresenter
{
    protected override void TryOccupieCell(GameObject droppedGameObject)
    {
        if (droppedGameObject.TryGetComponent<InventoryItem>(out InventoryItem inventoryItem))
            GetCell().Occupie(inventoryItem);
    }
}
