using UnityEngine;

public abstract class ItemParameters : ScriptableObject
{
    [ScriptableObjectId]
    public string Id;

    [field: Space(10), SerializeField] public string ItemTitle { get; private set; }
    [field: SerializeField] public Sprite ItemSprite { get; private set; }
    [field: Space(10), SerializeField] public int CountInStack { get; private set; }
    [field: SerializeField] public float OneItemWeight { get; private set; }
    [field: Space(10), SerializeField] public string ActionTitle { get; private set; }
}
