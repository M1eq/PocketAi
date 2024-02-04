using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas _inventoryCanvas;
    private RectTransform _rectTransform;
    private Image _draggableItemImage;
    private Transform _snapParent;
    private Cell _currentCell;

    public void Initialize(Canvas inventoryCanvas)
    {
        _inventoryCanvas = inventoryCanvas;
        _rectTransform = GetComponent<RectTransform>();
        _draggableItemImage = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SetSnapParent(transform.parent, _currentCell);
        transform.SetParent(_inventoryCanvas.transform);
        transform.SetAsLastSibling();

        _draggableItemImage.raycastTarget = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = _snapParent;
        transform.localPosition = Vector3.zero;

        _draggableItemImage.raycastTarget = true;
    }

    public void OnDrag(PointerEventData eventData) =>
        _rectTransform.anchoredPosition += eventData.delta / _inventoryCanvas.scaleFactor;

    public void SetSnapParent(Transform snapParent, Cell cell)
    {
        if (_currentCell != null)
            _currentCell.ResetCell();

        _currentCell = cell;
        _snapParent = snapParent;
    }
}
