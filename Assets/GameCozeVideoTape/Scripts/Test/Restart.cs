using SaveLoadSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

public class Restart : MonoBehaviour
{
    private Saver _saver;

    [Inject]
    private void Construct(Saver saver)
    {
        _saver = saver;
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetLevel();
        }

        if (Keyboard.current.kKey.wasPressedThisFrame)
        {
            SaveLevel();
        }
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadLevel();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(0);
    }

    private void SaveLevel()
    {
        _saver.Save();
    }

    private void LoadLevel()
    {
        _saver.Load();
    }
}
