using System;
using Zenject;

public class ImporterListenerFailInstallControlFullScreenTutorial : IDisposable, IInitializable
{
    private ListenerFailInstallCassete _listenerFailInstallCassete;
    private ControlFullScreenTutorial _controlFullScreenTutorial;

    public ImporterListenerFailInstallControlFullScreenTutorial(ListenerFailInstallCassete listenerFailInstallCassete, ControlFullScreenTutorial controlFullScreenTutorial)
    {
        _listenerFailInstallCassete = listenerFailInstallCassete;
        _controlFullScreenTutorial = controlFullScreenTutorial;
    }

    public void Dispose()
    {
        _listenerFailInstallCassete.OnComplited -= OnComplited;
    }

    public void Initialize()
    {
        _listenerFailInstallCassete.Initialize();
        _listenerFailInstallCassete.OnComplited += OnComplited;
    }

    private void OnComplited()
    {
        Dispose();
        _controlFullScreenTutorial.SetPanel(1);
    }
}