using System;
using UnityEngine;
using Zenject;

public class ImporterSystemCallPlayerInventory : IDisposable, IInitializable
{
    private PlayerUi _playerCanvas;
    private DialogSystemCall _dialogSystemCall;
    private InventoryCassette _playerInventory;

    public ImporterSystemCallPlayerInventory(DialogSystemCall dialogSystemCall, InventoryCassette playerInventory, PlayerUi playerCanvas)
    {
        _dialogSystemCall = dialogSystemCall;
        _playerInventory = playerInventory;
        _playerCanvas = playerCanvas;
    }

    public void Initialize()
    {
        _dialogSystemCall.OnStateDialog += OnStateDialog;
    }

    public void Dispose()
    {
        _dialogSystemCall.OnStateDialog -= OnStateDialog;
    }

    public void OnStateDialog(bool isState)
    {
        _playerInventory.VisibleHand(!isState);
        _playerCanvas.ChangeOtherGoup(!isState);
    }
}
