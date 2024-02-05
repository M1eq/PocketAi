using UnityEngine;
using UnityEngine.Events;

public class ClothesEquiper : MonoBehaviour
{
    public HeadClothes HeadClothes => _headClothes;
    public BodyClothes BodyClothes => _bodyClothes;

    public event UnityAction<int> HeadClothesEquiped;
    public event UnityAction<int> BodyClothesEquiped;
    public event UnityAction HeadClothesReseted;
    public event UnityAction BodyClothesReseted;

    [SerializeField] private ClothesCell _headClothesCell;
    [SerializeField] private ClothesCell _bodyClothesCell;

    private HeadClothes _headClothes;
    private BodyClothes _bodyClothes;

    public void EquipHeadClothes(HeadClothes headClothes)
    {
        if (_headClothes != null)
            headClothes.transform.parent.GetComponent<Cell>().Occupie(_headClothes);

        _headClothes = headClothes;
        _headClothesCell.Occupie(_headClothes);

        HeadClothesEquiped?.Invoke(_headClothes.Protection);
    }

    public void EquipBodyClothes(BodyClothes bodyClothes)
    {
        if (_bodyClothes != null)
            bodyClothes.transform.parent.GetComponent<Cell>().Occupie(_bodyClothes);

        _bodyClothes = bodyClothes;
        _bodyClothesCell.Occupie(_bodyClothes);

        BodyClothesEquiped?.Invoke(_bodyClothes.Protection);
    }

    public void TryResetEquipedClothes()
    {
        if (_headClothesCell.Occupied == false)
        {
            _headClothes = null;
            HeadClothesReseted?.Invoke();
        }

        if (_bodyClothesCell.Occupied == false)
        {
            _bodyClothes = null;
            BodyClothesReseted?.Invoke();
        }
    }
}
