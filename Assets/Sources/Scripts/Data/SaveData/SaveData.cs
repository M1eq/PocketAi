[System.Serializable]
public class SaveData 
{
    public InventoryItem[] InventoryItems;

    public Weapon EquipedWeapon;
    public HeadClothes EquipedHeadClothes;
    public BodyClothes EquipedBodyClothes;

    public int PlayerHealth = 100;
    public int EnemyHealth = 100;
}
