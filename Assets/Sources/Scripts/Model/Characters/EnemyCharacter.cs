using UnityEngine;

public class EnemyCharacter : Character
{
    public int Damage => _enemyParameters.Damage;

    [SerializeField] private EnemyHealthPresenter _enemyHealthPresenter;
    [SerializeField] private EnemyParameters _enemyParameters;

    public void Initialize(ItemCreator itemCreator)
    {
        InitializeHealth(new Health(_enemyParameters.MaxHealth));
        _enemyHealthPresenter.Initialize(itemCreator);
    }
}
