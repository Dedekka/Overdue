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
    private EventInstance _eventInstance;
    private EventReference _tempVoice;

    public AudioManager(AudioSettings audioSettings)
    {
        _pickUp = audioSettings.PickUp;
        _snapCorrect = audioSettings.SnapCorrect;
        _snapWrong = audioSettings.SnapWrong;
        _drop = audioSettings.Drop;
    }

    public void Dispose()
    {
        StopVoice();
    }

    public void PauseVoise(bool isPause)
    {
        if (!CheckEvent()) { return; }

        _eventInstance.setPaused(isPause);
    }

    public void SetVoice(EventReference eventReference)
    {
        _tempVoice = eventReference;
    }

    public void PlayVoice()
    {
        PlayVoise(_tempVoice);
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
        if (CheckEvent())
        {
            _eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        }
        _eventInstance.release();
    }

    private void Play(EventReference eventReference)
    {
        if (!eventReference.IsNull)
        {
            RuntimeManager.PlayOneShot(eventReference);
        }
    }

    private void PlayVoise(EventReference eventReference)
    {
        if (eventReference.IsNull) { return; }
        CheckPlayingVoise(eventReference);
        _eventInstance.start();
    }

    private void CheckPlayingVoise(EventReference eventReference)
    {
        StopVoice();
        _eventInstance = RuntimeManager.CreateInstance(eventReference);
    }

    private bool CheckEvent()
    {
        if (!_eventInstance.isValid())
        {
            return false;
        }

        _eventInstance.getPlaybackState(out FMOD.Studio.PLAYBACK_STATE state);

        return state == FMOD.Studio.PLAYBACK_STATE.PLAYING  // событие играет
        || state == FMOD.Studio.PLAYBACK_STATE.STARTING  // событие начинает играть
        || state == FMOD.Studio.PLAYBACK_STATE.SUSTAINING  // событие еще нельзя запустить
        || state == FMOD.Studio.PLAYBACK_STATE.STOPPING;  // событие еще нельзя запустить
    }

   

    //public void Play()
    //{
    //    if (!_sound.IsNull)
    //    {
    //        RuntimeManager.PlayOneShot(_sound);
    //    }
    //}

    //public void PlayHit(Vector3 Pos = new Vector3()) // Вызов другого звука 
    //{
    //    FMOD.Studio.EventInstance playHit = RuntimeManager.CreateInstance(_sound); // Создаем событие Звука 

    //    playHit.set3DAttributes(RuntimeUtils.To3DAttributes(Pos)); // Мы вводим информацию об положении в 3Д , а                       
    //                                                               //(RuntimeUtils.To3DAttributes) переводит наш Vector3 В понятный для Код 

    //    //playHit.setParameterByName("Size", transform.localScale.x);// Мы отправляем значение для параметра Size , по хорошему нужно 
    //    // разобраться как использовать ID 
    //    playHit.start(); // Запускаем воспроизведение 
    //    playHit.release(); // освобождаем память от этого события 
    //}
}
