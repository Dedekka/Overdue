using UnityEngine;

public class ControlLogic
{
    private LoadingSystem _loadingSystem;
    private ControlGameAnalytics _controlGameAnalytics;

    public ControlLogic(LoadingSystem loadingSystem, ControlGameAnalytics controlGameAnalytics)
    {
        _loadingSystem = loadingSystem;
        _controlGameAnalytics = controlGameAnalytics;
    }

    public void StartGame()
    {
        _loadingSystem.LoadScene(SceneIndex.Game);
    }

    public void BackMenu()
    {
        _loadingSystem.LoadScene(SceneIndex.Menu);
    }

    public void FeedbackMenu()
    {
        _loadingSystem.LoadScene(SceneIndex.FeedbackMenu);
    }

    public void Exit()
    {
        _controlGameAnalytics.ExitEvent();
        Application.Quit();
    }
}