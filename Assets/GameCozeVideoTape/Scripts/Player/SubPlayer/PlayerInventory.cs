using System;
using UnityEngine;
using Zenject;

public class PlayerInventory : IDisposable, IInitializable
{
    private readonly Transform _hand;
    private readonly int _countSlotInventory;

    public PlayerInventory(SettingsPlayer settingsPlayer, Transform hand)
    {
        _countSlotInventory = settingsPlayer.CountSlotInventory;
        _hand = hand;
    }

    public void Dispose()
    {

    }

    public void Initialize()
    {

    }


}
