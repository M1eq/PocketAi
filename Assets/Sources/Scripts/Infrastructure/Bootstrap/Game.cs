public class Game
{
    private readonly GameStateMachine _gameStateMachine;

    public void ActivateBootstrapState() => _gameStateMachine.Enter<BootstrapState>();

    public Game()
    {
        _gameStateMachine = new GameStateMachine();
    }
}
