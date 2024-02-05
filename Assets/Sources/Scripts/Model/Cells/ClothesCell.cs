public class ClothesCell : Cell
{
    protected override bool GetOcupationCheckResult() => GetOccupiedItem() != null && transform.childCount > 0;
}
