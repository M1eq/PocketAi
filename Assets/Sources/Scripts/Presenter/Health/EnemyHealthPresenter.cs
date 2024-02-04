using UnityEngine;

public class EnemyHealthPresenter : HealthPresenter
{
    [SerializeField] private ItemCreator _itemCreator;

    protected override void OnDied()
    {
        _itemCreator.TryCreateRandomLoot();
        RefillHealth();
    }
}
