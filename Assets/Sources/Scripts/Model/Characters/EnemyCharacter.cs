using UnityEngine;

public class EnemyCharacter : Character
{
    public int Damage => _enemyParameters.Damage;

    [SerializeField] private EnemyHealthPresenter _enemyHealthPresenter;
    [SerializeField] private EnemyParameters _enemyParameters;

    private JsonSaveSystem _jsonSaveSystem;
    private Health _enemyHealth;

    public void Initialize(ItemCreator itemCreator, JsonSaveSystem jsonSaveSystem)
    {
        _jsonSaveSystem = jsonSaveSystem;
        _jsonSaveSystem.Load();

        _enemyHealth = new Health();
        _enemyHealth.Initialize(_enemyParameters.MaxHealth, _jsonSaveSystem.SaveData.EnemyHealth);

        Debug.Log(_jsonSaveSystem.SaveData.EnemyHealth);

        InitializeHealth(_enemyHealth);
        _enemyHealthPresenter.Initialize(itemCreator);
    }

    public void SaveEnemyData()
    {
        _jsonSaveSystem.SaveData.EnemyHealth = _enemyHealth.CurrentHealth;
        _jsonSaveSystem.Save();
    }
}
