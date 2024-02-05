using UnityEngine;

public abstract class HealthPresenter : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private HealthCountShower _healthCountShower;

    protected abstract void OnDied();
    protected void RefillHealth() => _character.Health.RefillHealth();

    private void OnHealthCountChanged(int currentHealth, int maxHealth) => 
        _healthCountShower.Show(currentHealth, maxHealth);

    private void OnEnable()
    {
        _character.Health.Died += OnDied;
        _character.Health.HealthCountChanged += OnHealthCountChanged;
    }

    private void OnDisable()
    {
        _character.Health.Died -= OnDied;
        _character.Health.HealthCountChanged -= OnHealthCountChanged;
    }
}
