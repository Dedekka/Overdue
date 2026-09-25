using System;
using Zenject;

public class TutorialSystem : IInitializable, IDisposable
{
    private ControlInputListener _controlInputListener;

    public TutorialSystem(ControlInputListener controlInputListener)
    {
        _controlInputListener = controlInputListener;
    }

    public void Initialize()
    {
        _controlInputListener.ActiveListener();
    }

    public void Dispose()
    {

    }
}