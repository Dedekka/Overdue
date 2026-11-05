using SaveLoadSystem;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Zenject;

public class Restart : MonoBehaviour
{
    private Saver _saver;
    private ControlPhoneAnswer _phone;
    private PresentEventManager _realizerPresent;

    [Inject]
    private void Construct(Saver saver, PresentEventManager realizerPresent, ControlPhoneAnswer phone)
    {
        _saver = saver;
        _realizerPresent = realizerPresent;
        _phone = phone;
    }

    private void Start()
    {
        _saver.Initialize();
    }

    private void Update()
    {
        ActivePhoneRing();


        //if (Keyboard.current.pKey.wasPressedThisFrame)
        //{
        //    ResetLevel();
        //}

        //if (Keyboard.current.kKey.wasPressedThisFrame)
        //{
        //    SaveLevel();
        //}
        //if (Keyboard.current.lKey.wasPressedThisFrame)
        //{
        //    LoadLevel();
        //}
        //if (Gamepad.current.bButton.wasPressedThisFrame)
        //{

        //    _realizerPresent.SetCallData(new PresentEvent()
        //    {
        //        IDCassette = 0,
        //        IDPresent = 1
        //    });
        //    _realizerPresent.ActiveEvent();
        //}

        //if (Keyboard.current.digit1Key.wasPressedThisFrame)
        //{

        //    _realizerPresent.SetCallData(new PresentEvent()
        //    {
        //        IDCassette = 0,
        //        IDPresent = 1
        //    });
        //    _realizerPresent.ActiveEvent();
        //}

        //if (Keyboard.current.digit2Key.wasPressedThisFrame)
        //{
        //    _realizerPresent.SetCallData(new CallData()
        //    {
        //        IdCassetts = 0,
        //        IDPresent = 3
        //    });
        //}

        //if (Keyboard.current.digit3Key.wasPressedThisFrame)
        //{
        //    _realizerPresent.SetCallData(new CallData()
        //    {
        //        IdCassetts = 0,
        //        IDPresent = 6
        //    });
        //}

        //if (Keyboard.current.digit4Key.wasPressedThisFrame)
        //{
        //    _realizerPresent.SetCallData(new CallData()
        //    {
        //        IdCassetts = 0,
        //        IDPresent = 7
        //    });
        //}
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

    private void ActivePhoneRing()
    {
        if (Gamepad.current == null) { return; }
        if (Gamepad.current.bButton.wasReleasedThisFrame)
        {
            Debug.Log("ActivePhoneRing");
            _phone.SetEvent(new PhoneEvent()
            {
                CountCassette = 0,
                IDDialogue = 1,
                IdEventHistory = 1
            });
        }
    }
}
