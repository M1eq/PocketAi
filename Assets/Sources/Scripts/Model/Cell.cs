using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    private Image _cellImage;

    public void Occupie(DraggableItem draggableItem)
    {
        draggableItem.SetSnapParent(_cellImage.transform);
        draggableItem.transform.parent = _cellImage.transform;
        draggableItem.transform.localPosition = Vector3.zero;
        draggableItem.transform.localScale = Vector3.one;
    }

    private void Awake() => _cellImage = GetComponent<Image>();
}
