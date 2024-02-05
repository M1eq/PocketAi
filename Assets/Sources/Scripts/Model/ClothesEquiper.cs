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
        _headClothes = headClothes;
        HeadClothesEquiped?.Invoke(_headClothes.Protection);
    }

    public void EquipBodyClothes(BodyClothes bodyClothes)
    {
        _bodyClothes = bodyClothes;
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
