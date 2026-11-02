using System;
using Zenject;

public class ListenerWaitDialog : IDisposable, IInitializable
{
    private PlayerSaySystem _playerSaySystem;
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    private bool _activeListener;

    public ListenerWaitDialog(PlayerSaySystem playerSaySystem,ControlFullScreenTutorial controlFullScreenTutorial)
    {
        _controlFullScreenTutorial = controlFullScreenTutorial;
        _playerSaySystem = playerSaySystem;
        _activeListener = false;
    }

    public void Initialize()
    {
        _playerSaySystem.OnWaitDialog += OnWaitDialog;
    }

    public void Dispose()
    {
        _playerSaySystem.OnWaitDialog -= OnWaitDialog;
        _controlFullScreenTutorial.OnStateFullScreenTutorial -= OnStateFullScreenTutorial;
    }

    private void OnWaitDialog()
    {
        if (_activeListener) { return; }
        ControlSub(true);
    }

    private void OnStateFullScreenTutorial(bool isActive)
    {
        if (!isActive)
        {
            _playerSaySystem.ActiveDialogue();
            ControlSub(false);
        }
    }

    private void ControlSub(bool isStateSub)
    {
        _activeListener = isStateSub;
        if (_activeListener)
        {
            _controlFullScreenTutorial.OnStateFullScreenTutorial += OnStateFullScreenTutorial;
        }
        else
        {
            _controlFullScreenTutorial.OnStateFullScreenTutorial -= OnStateFullScreenTutorial;
        }
    }
}