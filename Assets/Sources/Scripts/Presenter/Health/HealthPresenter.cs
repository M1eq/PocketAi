using UnityEngine;

public abstract class HealthPresenter : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private HealthCountShower _healthCountShower;

    protected abstract void OnDied();
    protected void RefillHealth() => _health.RefillHealth();
    private void OnHealthCountChanged(int currentHealth) => _healthCountShower.Show(currentHealth);

    private void OnEnable()
    {
        _health.Died += OnDied;
        _health.HealthCountChanged += OnHealthCountChanged;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
        _health.HealthCountChanged -= OnHealthCountChanged;
    }
}
