using UnityEngine.Events;

public class Health
{
    public int CurrentHealth => _currentHealth;

    public event UnityAction Died;
    public event UnityAction<int, int> HealthCountChanged;

    private int _maxHealth;
    private int _currentHealth;

    public void RefillHealth() => _currentHealth = _maxHealth;

    public void Initialize(int maxHealth, int savedHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = savedHealth;
    }

    public void RestoreHP(MedKitParameters medKitParameters)
    {
        _currentHealth += medKitParameters.RestoreHealthCount;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthCountChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        TryDie();

        HealthCountChanged?.Invoke(_currentHealth, _maxHealth);
    }

    private void TryDie()
    {
        if (_currentHealth <= 0)
            Died?.Invoke();
    }
}
