using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public event UnityAction Died;
    public event UnityAction<int> HealthCountChanged;

    [SerializeField] private int _maxHealth = 100;

    private int _currentHealth;

    public void RefillHealth() => _currentHealth = _maxHealth;

    public void RestoreHP(MedKitParameters medKitParameters)
    {
        _currentHealth += medKitParameters.RestoreHealthCount;

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        HealthCountChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        TryDie();

        HealthCountChanged?.Invoke(_currentHealth);
    }

    private void TryDie()
    {
        if (_currentHealth <= 0)
            Died?.Invoke();
    }
}
