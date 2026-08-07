using System;
using UnityEngine;
using Zenject;

public class ImporterPhonePlayerStateControl : IDisposable, IInitializable
{
    // Зарегистрировать Phone
    // Зарегистрировать ImporterPhonePlayerStateControl

    private Phone _phone;
    private PlayerStateControl _playerStateControl;

    public ImporterPhonePlayerStateControl(Phone phone, PlayerStateControl playerStateControl)//SystemBuss systemBuss, 
    {
        _phone = phone;
        _playerStateControl = playerStateControl;
    }

    public void Initialize()
    {
        _phone.OnStartCall += OnStartCall;
    }


    public void Dispose()
    {
        _phone.OnStartCall += OnStartCall;
    }


    private void OnStartCall()
    {
        _playerStateControl.ChangeStateControlPlayer(false);
    }
  
}
