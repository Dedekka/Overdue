using System;
using UnityEngine;
using Zenject;

public class ImporterPlayerLookItemState : IDisposable, IInitializable
{
    private PlayerLookItem _playerLookItem;
    private PlayerStateControl _playerStateControl;

    public ImporterPlayerLookItemState(PlayerLookItem playerLookItem, PlayerStateControl playerStateControl)
    {
        _playerLookItem = playerLookItem;
        _playerStateControl = playerStateControl;
    }

    public void Initialize()
    {
        _playerLookItem.OnStateLookItem += OnStateLookItem;
    }

    public void Dispose()
    {
        _playerLookItem.OnStateLookItem -= OnStateLookItem;
    }

    private void OnStateLookItem(bool isActiveControlPlayer)
    {
        _playerStateControl.ChangeStateControlPlayer(!isActiveControlPlayer);
    }
}