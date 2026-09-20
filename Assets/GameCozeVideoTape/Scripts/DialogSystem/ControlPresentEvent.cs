using System;
using Zenject;

public class ControlPresentEvent : IDisposable, IInitializable
{
    private PresentEffect _presentEffect;
    private PresentEventManager _dialogEventManager;
    private PresentEvent _presentEvent;

    public event Action OnEventComplited;

    public ControlPresentEvent(PresentEventManager dialogEventManager, PresentEffect presentEffect)
    {
        _dialogEventManager = dialogEventManager;
        _presentEffect = presentEffect;
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
        _presentEffect.ActivationPresentEffect();
    }
}