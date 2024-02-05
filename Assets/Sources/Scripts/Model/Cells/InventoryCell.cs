public class InventoryCell : Cell
{
    protected override bool GetOcupationCheckResult() => GetOccupiedItem() != null; 
}
