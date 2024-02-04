public class Game
{
    private readonly GameStateMachine _gameStateMachine;

    public void ActivateBootstrapState() => _gameStateMachine.Enter<BootstrapState>();

    public Game(GameBootstrapper gameBootstrapper)
    {
        _gameStateMachine = new GameStateMachine(new SceneLoader(gameBootstrapper));
    }
}
