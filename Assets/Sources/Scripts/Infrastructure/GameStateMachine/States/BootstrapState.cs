public class BootstrapState : IState
{
    private const string InitialSceneName = "Initial";
    private readonly GameStateMachine _gameStateMachine;
    private readonly SceneLoader _sceneLoader; 

    public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader)
    {
        _gameStateMachine = gameStateMachine;
        _sceneLoader = sceneLoader;
    }

    public void Enter() => _sceneLoader.LoadScene(InitialSceneName, OnInitialSceneLoaded);
    private void OnInitialSceneLoaded() => _gameStateMachine.Enter<DataLoadState>();
}
