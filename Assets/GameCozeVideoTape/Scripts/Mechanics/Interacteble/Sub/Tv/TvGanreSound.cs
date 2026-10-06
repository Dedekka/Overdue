using FMODUnity;
using System;
using UnityEngine;

public class TvGanreSound
{
    private EventReference _tempVoice;

    public event Action<EventReference> OnChangeTvGanre;
    public event Action OnPlayTvGanre;
    public event Action OnStopPlayTvGanre;

    public void SetFmodSound(string dialogLine)
    {
        _tempVoice = RuntimeManager.PathToEventReference(dialogLine);
        OnChangeTvGanre?.Invoke(_tempVoice);
    }

    public void StartSound()
    {
        OnPlayTvGanre?.Invoke();
    }

    public void StopSound()
    {
        OnStopPlayTvGanre?.Invoke();
    }
}