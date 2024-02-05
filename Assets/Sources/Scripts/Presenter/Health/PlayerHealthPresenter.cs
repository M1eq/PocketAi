public class PlayerHealthPresenter : HealthPresenter
{
    private LoseMenu _loseMenu;

    public void Initialize(LoseMenu loseMenu) => _loseMenu = loseMenu;
    protected override void OnDied() => _loseMenu.gameObject.SetActive(true);
}
