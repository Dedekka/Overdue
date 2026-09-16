using UnityEngine;

public class ControlLogic 
{
   private LoadingSystem _loadingSystem;

    public ControlLogic(LoadingSystem loadingSystem)
    {
        _loadingSystem = loadingSystem;
    }

    public void StartGame()
    {
        _loadingSystem.LoadScene(SceneIndex.Game);
    }

    public void BackMenu()
    {
        _loadingSystem.LoadScene(SceneIndex.Menu);
    }

    public void Exit()
    {
        Application.Quit();
    }
}