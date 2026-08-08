using Cysharp.Threading.Tasks;
using System;
using Zenject;

public class ImporterDialogEventManager : IDisposable, IInitializable
{
    private DialogEvent _dialogEvent;
    private DialogEventManager _dialogEventManager;

    public ImporterDialogEventManager(DialogEvent dialogEvent, DialogEventManager dialogEventManager)
    {
        _dialogEvent = dialogEvent;
        _dialogEventManager = dialogEventManager;
    }

    public void Initialize()
    {
        _dialogEvent.OnCallData += OnCallData;
    }

    public void Dispose()
    {
        _dialogEvent.OnCallData -= OnCallData;
    }

    private void OnCallData(CallData callData)
    {
        _dialogEventManager.SetCallData(callData);
        _dialogEventManager.ActiveEvent();
    }
}