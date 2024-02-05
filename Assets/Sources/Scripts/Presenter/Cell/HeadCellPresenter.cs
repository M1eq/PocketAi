using UnityEngine;

public class HeadCellPresenter : CellPresenter
{
    [SerializeField] private ClothesEquiper _clothesEquiper;

    protected override void TryOccupieCell(GameObject droppedGameObject)
    {
        if (GetCell().Occupied == false)
        {
            if (droppedGameObject.TryGetComponent<HeadClothes>(out HeadClothes headClothes))
            {
                GetCell().Occupie(headClothes);
                _clothesEquiper.EquipHeadClothes(headClothes);
            }
        }
    }
}
