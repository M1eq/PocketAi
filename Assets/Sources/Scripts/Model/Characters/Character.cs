using UnityEngine;
using UnityEngine.Events;

public abstract class Character : MonoBehaviour
{
    public Health Health => _health;
    public event UnityAction HealthInitialized;

    private Health _health;

    protected void InitializeHealth(Health health)
    {
        _health = health;
        HealthInitialized?.Invoke();
    }
}
