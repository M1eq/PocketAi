using UnityEngine;
using Zenject;

public class EnemyCharacter : Character
{
    [SerializeField] private EnemyHealthPresenter _enemyHealthPresenter;

    public void Initialize(ItemCreator itemCreator)
    {
        InitializeHealth(new Health());
        _enemyHealthPresenter.Initialize(itemCreator);
    }
}
