using UnityEngine;

public class InventoryCellPresenter : CellPresenter
{
    protected override void TryOccupieCell(GameObject droppedGameObject)
    {
        if (droppedGameObject.TryGetComponent<DraggableItem>(out DraggableItem draggableItem))
            GetCell().Occupie(draggableItem);
    }
}
