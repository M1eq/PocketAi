using UnityEngine;

public class ClothesEquiper : MonoBehaviour
{
    public HeadClothes HeadClothes => _headClothes;
    public BodyClothes BodyClothes => _bodyClothes;

    [SerializeField] private ClothesCell _headClothesCell;    
    [SerializeField] private ClothesCell _bodyClothesCell;

    private HeadClothes _headClothes;
    private BodyClothes _bodyClothes;

    public void EquipHeadClothes(HeadClothes headClothes) => _headClothes = headClothes;
    public void EquipBodyClothes(BodyClothes bodyClothes) => _bodyClothes = bodyClothes;

    public void TryResetEquipedClothes()
    {
        if (_headClothesCell.Occupied == false)
            _headClothes = null;

        if (_bodyClothesCell.Occupied == false)
            _bodyClothes = null;
    }
}
