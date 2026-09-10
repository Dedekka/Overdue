using FMODUnity;
using System;
using UnityEngine.Video;

public class DialogSound
{
    private EventReference _tempVoice;

    public event Action<EventReference> OnChangeVoice;
    public event Action OnPlayVoice;
    public event Action OnStopPlayVoice;

    public void SetFmodSound(string dialogLine)
    {
        _tempVoice = RuntimeManager.PathToEventReference(dialogLine);
        OnChangeVoice?.Invoke(_tempVoice);
    }

    public void StartSound()
    {
        OnPlayVoice?.Invoke();
    }

    public void StopSound()
    {
        OnStopPlayVoice?.Invoke();
    }
}
