using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private readonly GameBootstrapper _coroutineLauncher;

    public SceneLoader(GameBootstrapper gameBootstrapper) => _coroutineLauncher = gameBootstrapper;

    public void LoadScene(string sceneName, Action onLoaded = null) => 
        _coroutineLauncher.StartCoroutine(LoadSceneCoroutine(sceneName, onLoaded));

    private IEnumerator LoadSceneCoroutine(string sceneName, Action onLoaded = null)
    {
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            onLoaded?.Invoke();
            yield break;
        }

        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);

        while (waitNextScene.isDone == false)
            yield return null;

        onLoaded?.Invoke();
    }
}
