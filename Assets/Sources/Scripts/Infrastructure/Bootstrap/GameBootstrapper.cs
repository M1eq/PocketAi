using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private Game _game;

    private void Awake()
    {
        _game = new Game(this);
        _game.ActivateBootstrapState();
        DontDestroyOnLoad(this);
    }
}
