using UnityEngine;

public class BodyCellPresenter : CellPresenter
{
    [SerializeField] private ClothesEquiper _clothesEquiper;

    protected override void TryOccupieCell(GameObject droppedGameObject)
    {
        if (GetCell().Occupied == false)
        {
            if (droppedGameObject.TryGetComponent<BodyClothes>(out BodyClothes bodyClothes))
            {
                GetCell().Occupie(bodyClothes);
                _clothesEquiper.EquipBodyClothes(bodyClothes);
            }
        }
    }
}
