[System.Serializable]
public class SaveData 
{
    public InventoryItem[] InventoryItems;

    public HeadClothes EquipedHeadClothes;
    public BodyClothes EquipedBodyClothes;
    public AmmoType EquipedWeaponAmmoType = AmmoType.pistolAmmo;

    public int PlayerHealth = 100;
    public int EnemyHealth = 100;
}
