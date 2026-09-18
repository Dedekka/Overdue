using System;
using Zenject;

public class ControlPresentEvent : IDisposable, IInitializable
{
    private PresentEventManager _dialogEventManager;
    private PresentEvent _presentEvent;

    public event Action OnEventComplited;

    public ControlPresentEvent(PresentEventManager dialogEventManager)
    {
        _dialogEventManager = dialogEventManager;
    }

    public void Initialize()
    {
        _dialogEventManager.OnEventComplited += OnEventComplited;
    }

    public void Dispose()
    {
        _dialogEventManager.OnEventComplited -= OnEventComplited;
    }

    public void SetEvent(PresentEvent presentEvent)
    {
        _presentEvent = presentEvent;
        ActiveEvent();
    }

    public void ActiveEvent()
    {
        _dialogEventManager.SetCallData(_presentEvent);
        _dialogEventManager.ActiveEvent();
    }
}