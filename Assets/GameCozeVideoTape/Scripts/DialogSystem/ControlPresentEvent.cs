using System;
using Zenject;

public class ControlPresentEvent : IDisposable, IInitializable
{
    private PresentEffect _presentEffect;
    private PresentEventManager _presentEventManager;
    private PresentEvent _presentEvent;

    public event Action OnEventComplited;

    public ControlPresentEvent(PresentEventManager dialogEventManager, PresentEffect presentEffect)
    {
        _presentEventManager = dialogEventManager;
        _presentEffect = presentEffect;
    }

    public void Initialize()
    {
        _presentEventManager.OnEventComplited += OnEventComplited;
    }

    public void Dispose()
    {
        _presentEventManager.OnEventComplited -= OnEventComplited;
    }

    public void SetEvent(PresentEvent presentEvent)
    {
        _presentEvent = presentEvent;
        ActiveEvent();
    }

    public void ActiveEvent()
    {
        _presentEffect.SetCallData(_presentEvent);
        _presentEventManager.SetCallData(_presentEvent);
        _presentEventManager.ActiveEvent();
        _presentEffect.ActivationPresentEffect();
    }
}