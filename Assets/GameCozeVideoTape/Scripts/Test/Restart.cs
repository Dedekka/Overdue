using SaveLoadSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

public class Restart : MonoBehaviour
{
    private Saver _saver;
    private RealizerPresent _realizerPresent;

    [Inject]
    private void Construct(Saver saver, RealizerPresent realizerPresent)
    {
        _saver = saver;
        _realizerPresent = realizerPresent;
    }

    private void Start()
    {
        _saver.Initialize();
    }

    private void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
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

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            _realizerPresent.SetCallData(new CallData()
            {
                IdCassetts = 0,
                IDPresent = 1
            });
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            _realizerPresent.SetCallData(new CallData()
            {
                IdCassetts = 0,
                IDPresent = 2
            });
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            _realizerPresent.SetCallData(new CallData()
            {
                IdCassetts = 0,
                IDPresent = 3
            });
        }

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            _realizerPresent.SetCallData(new CallData()
            {
                IdCassetts = 0,
                IDPresent = 4
            });
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void ResetLevel()
    {
        SceneManager.LoadScene(1);
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
