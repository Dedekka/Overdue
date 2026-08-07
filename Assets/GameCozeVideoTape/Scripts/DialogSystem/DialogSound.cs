using FMODUnity;
using System;

public class DialogSound
{
    private EventReference _tempVoice;

    public event Action<EventReference> OnChangeVoice;
    public event Action OnPlayVoice;
    public event Action OnStopPlayVoice;

    public void SetFmodSound(DialogLine dialogLine)
    {
        _tempVoice = RuntimeManager.PathToEventReference(dialogLine.SoundLine);
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
