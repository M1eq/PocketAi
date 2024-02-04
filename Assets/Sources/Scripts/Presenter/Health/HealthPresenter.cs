using UnityEngine;

public abstract class HealthPresenter : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private HealthCountShower _healthCountShower;

    protected abstract void OnDied();
    protected void RefillHealth() => _character.Health.RefillHealth();
    private void OnHealthCountChanged(int currentHealth) => _healthCountShower.Show(currentHealth);

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
