public class EnemyHealthPresenter : HealthPresenter
{
    private ItemCreator _itemCreator;

    public void Initialize(ItemCreator itemCreator) => _itemCreator = itemCreator;

    protected override void OnDied()
    {
        _itemCreator.TryCreateRandomLoot();
        RefillHealth();
    }
}
