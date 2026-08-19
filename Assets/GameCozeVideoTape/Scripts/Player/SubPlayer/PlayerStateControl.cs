using System;
using UnityEngine;

public class PlayerStateControl
{
    private bool _isPlayerControlON;
    public event Action<bool> OnChangeStateControlPlayer;

    public PlayerStateControl()
    {
        _isPlayerControlON = true;
    }

    public void ChangeStateControlPlayer(bool isPlayerControlON)
    {
        if (_isPlayerControlON == isPlayerControlON) { return; }
        _isPlayerControlON = isPlayerControlON;
        OnChangeStateControlPlayer?.Invoke(_isPlayerControlON);
    }
}