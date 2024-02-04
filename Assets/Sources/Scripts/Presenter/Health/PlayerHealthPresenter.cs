using UnityEngine;

public class PlayerHealthPresenter : HealthPresenter
{
    [SerializeField] private GameObject _loseMenu;

    protected override void OnDied() => _loseMenu.SetActive(true);
}
