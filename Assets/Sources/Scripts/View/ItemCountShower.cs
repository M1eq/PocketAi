using TMPro;
using UnityEngine;

public class ItemCountShower : MonoBehaviour
{
    [SerializeField] private TMP_Text _itemCountText;

    public void TryShowItemCount(int itemCount)
    {
        if (itemCount > 1)
        {
            _itemCountText.gameObject.SetActive(true);
            _itemCountText.text = itemCount.ToString();
        }
        else
        {
            _itemCountText.gameObject.SetActive(false);
        }
    }
}
