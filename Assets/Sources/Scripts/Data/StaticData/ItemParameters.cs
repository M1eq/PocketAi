using UnityEngine;

public enum ItemType
{
    consumables, bodyClothes, headClothes
}

public abstract class ItemParameters : ScriptableObject
{
    [field: SerializeField] public string ItemTitle { get; private set; }
    [field: SerializeField] public Sprite ItemSprite { get; private set; }
    [field: Space(10), SerializeField] public ItemType ItemType { get; private set; }
    [field: Space(10), SerializeField] public int CountInStack { get; private set; }
    [field: SerializeField] public float OneItemWeight { get; private set; }
    [field: Space(10), SerializeField] public string ActionTitle { get; private set; }
}
