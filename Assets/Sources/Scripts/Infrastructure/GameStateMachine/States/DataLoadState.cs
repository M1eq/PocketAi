public class DataLoadState : IState
{
    private readonly GameStateMachine _gameStateMachine;

    public DataLoadState(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Enter()
    {

    }
}
