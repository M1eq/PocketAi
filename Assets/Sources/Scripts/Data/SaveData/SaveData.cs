using System.Collections.Generic;

[System.Serializable]
public class SaveData 
{
    public List<string> ItemsId = new List<string>();
    public List<int> InventoryItemsCount = new List<int>();

    public string EquipedHeadClothesId;
    public string EquipedBodyClothesId;
    public AmmoType EquipedWeaponAmmoType = AmmoType.pistolAmmo;

    public int PlayerHealth = 100;
    public int EnemyHealth = 100;
}
