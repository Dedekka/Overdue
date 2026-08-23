using FMOD.Studio;
using FMODUnity;
using System;
using UnityEngine;

public class AudioManager : IDisposable
{
    [Header("OtherSound")]
    private EventReference _pickUp;
    private EventReference _snapCorrect;
    private EventReference _snapWrong;
    private EventReference _drop;

    [Header("VoiceSound")]
    private EventInstance _voiceInstance;
    private EventReference _tempVoice;

    [Header("MusicSound")]
    private EventInstance _musicInstance;
    private EventReference _tempMusic;

    public AudioManager(AudioSettings audioSettings)
    {
        _pickUp = audioSettings.PickUp;
        _snapCorrect = audioSettings.SnapCorrect;
        _snapWrong = audioSettings.SnapWrong;
        _drop = audioSettings.Drop;
    }

    public void Dispose()
    {
        StopSmartEvent(ref _voiceInstance);
        StopSmartEvent(ref _musicInstance);
    }

    public void PauseVoise(bool isPause)
    {
        if (!CheckEvent(_voiceInstance)) { return; }

        _voiceInstance.setPaused(isPause);
    }

    public void PauseMusic(bool isPause)
    {
        Debug.Log($"AudioManager,Pre PauseMusic, isPause: {isPause} ");
        if (!CheckEvent(_musicInstance)) { return; }

        Debug.Log($"AudioManager, POst PauseMusic, isPause: {isPause} ");
        _musicInstance.setPaused(isPause);
    }

    public void SetVoice(EventReference eventReference)
    {
        _tempVoice = eventReference;
    }

    public void SetMusic(EventReference eventReference)
    {
        _tempMusic = eventReference;
        StopSmartEvent(ref _musicInstance);
    }

    public void PlayVoice()
    {
        PlaySmartEvent(ref _tempVoice, ref _voiceInstance);
    }

    public void PlayMusic(bool _isPlaying)
    {
        Debug.Log($"AudioManager, PlayMusic, _isPlaying: {_isPlaying} ");
        if (CheckEvent(_musicInstance))
        {
            PauseMusic(!_isPlaying);
        }
        else if (_isPlaying)
        {
            PlaySmartEvent(ref _tempMusic, ref _musicInstance);
        }
    }

    public void PlayPickUp()
    {
        Play(_pickUp);
    }

    public void PlaySnapCorrect()
    {
        Play(_snapCorrect);
    }

    public void PlaySnapWrong()
    {
        Play(_snapWrong);
    }

    public void PlayDrop()
    {
        Play(_drop);
    }

    public void StopVoice()
    {
        StopSmartEvent(ref _voiceInstance);
    }

    public void StopSmartEvent(ref EventInstance eventInstance)
    {
        if (CheckEvent(eventInstance))
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        eventInstance.release();
    }

    private void Play(EventReference eventReference)
    {
        if (!eventReference.IsNull)
        {
            RuntimeManager.PlayOneShot(eventReference);
        }
    }

    private void PlaySmartEvent(ref EventReference eventReference, ref EventInstance eventInstance)
    {
        if (eventReference.IsNull) { return; }
        CheckPlayingSmartEvent(ref eventReference, ref eventInstance);
        eventInstance.start();
    }

    private void CheckPlayingSmartEvent(ref EventReference eventReference, ref EventInstance eventInstance)
    {
        StopSmartEvent(ref eventInstance);
        eventInstance = RuntimeManager.CreateInstance(eventReference);
    }

    private bool CheckEvent(EventInstance eventInstance)
    {
        if (!eventInstance.isValid())
        {
            return false;
        }

        eventInstance.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);

        return state == FMOD.Studio.PLAYBACK_STATE.PLAYING  // событие играет
        || state == FMOD.Studio.PLAYBACK_STATE.STARTING  // событие начинает играть
        || state == FMOD.Studio.PLAYBACK_STATE.SUSTAINING  // событие еще нельзя запустить
        || state == FMOD.Studio.PLAYBACK_STATE.STOPPING;  // событие еще нельзя запустить
    }
}
