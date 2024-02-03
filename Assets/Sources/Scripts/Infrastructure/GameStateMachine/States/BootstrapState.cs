public class BootstrapState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public BootstrapState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {
        _gameStateMachine.Enter<DataLoadState>();
    }
}
