using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Cell))]
public abstract class CellPresenter : MonoBehaviour, IDropHandler
{
    [SerializeField] private Cell _cell;

    public void OnDrop(PointerEventData eventData) => TryOccupieCell(eventData.pointerDrag.gameObject);
    protected Cell GetCell() => _cell;

    protected abstract void TryOccupieCell(GameObject droppedGameObject);
}
