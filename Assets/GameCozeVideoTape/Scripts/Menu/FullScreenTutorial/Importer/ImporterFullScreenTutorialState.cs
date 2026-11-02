using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class ImporterFullScreenTutorialState : IDisposable, IInitializable
{
    private PlayerUi _playerCanvas;
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    private PlayerStateControl _playerStateControl;

    public ImporterFullScreenTutorialState(ControlFullScreenTutorial controlFullScreenTutorial, PlayerStateControl playerStateControl, PlayerUi playerCanvas)
    {
        _controlFullScreenTutorial = controlFullScreenTutorial;
        _playerStateControl = playerStateControl;
        _playerCanvas = playerCanvas;
    }

    public void Initialize()
    {
        _controlFullScreenTutorial.OnStateFullScreenTutorial += OnStateLookItem;
    }

    public void Dispose()
    {
        _controlFullScreenTutorial.OnStateFullScreenTutorial -= OnStateLookItem;
    }

    private void OnStateLookItem(bool isActiveControlPlayer)
    {
        _playerStateControl.ChangeStateControlPlayer(!isActiveControlPlayer);
        _playerCanvas.ChangeOtherGoup(!isActiveControlPlayer);
    }

}