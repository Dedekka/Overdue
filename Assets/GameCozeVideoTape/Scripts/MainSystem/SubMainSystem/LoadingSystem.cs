using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSystem
{
    public void LoadScene(SceneIndex index)
    {
        SceneManager.LoadScene((int)index);
    }
}

public enum SceneIndex
{
    Menu,
    Game
}