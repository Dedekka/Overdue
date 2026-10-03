using System;
using UnityEngine;
using Zenject;

public class ImporterPhonePlayerInventory : IDisposable, IInitializable
{
    private Phone _phone;
    private PlayerInventory _playerInventory;

    public ImporterPhonePlayerInventory(Phone phone, PlayerInventory playerInventory)
    {
        _phone = phone;
        _playerInventory = playerInventory;
    }

    public void Initialize()
    {
        _phone.OnStartCall += OnStartCall;
    }

    public void Dispose()
    {
        _phone.OnStartCall -= OnStartCall;
    }

    public void OnStartCall()
    {
        _playerInventory.DropAllCassette();
        _playerInventory.DropAllPresent();
    }
}
