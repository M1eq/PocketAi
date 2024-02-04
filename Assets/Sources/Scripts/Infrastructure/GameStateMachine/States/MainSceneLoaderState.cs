public class MainSceneLoaderState : IState
{
    private const string MainSceneName = "GameScene";
    private readonly SceneLoader _sceneLoader;

    public MainSceneLoaderState(SceneLoader sceneLoader) => _sceneLoader = sceneLoader;
    public void Enter() => _sceneLoader.LoadScene(MainSceneName);
}
