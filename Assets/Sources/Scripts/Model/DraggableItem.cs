using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas _gameAreaCanvas;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Image _draggableItemImage;

    private Transform _snapParent;

    public void Construct(Canvas gameAreaCanvas)
    {
        _gameAreaCanvas = gameAreaCanvas;
        _rectTransform = GetComponent<RectTransform>();
        _draggableItemImage = GetComponent<Image>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        SetSnapParent(transform.parent);
        transform.SetParent(transform.root);
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
        _rectTransform.anchoredPosition += eventData.delta / _gameAreaCanvas.scaleFactor;

    public void SetSnapParent(Transform snapParent) => _snapParent = snapParent;
}
