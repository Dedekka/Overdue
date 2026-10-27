using FMOD.Studio;
using FMODUnity;
using System;
using UnityEngine;

public class AudioManager : IDisposable
{
    [Header("VoiceSound")]
    private EventInstance _voiceInstance;
    private EventReference _tempVoice;

    [Header("MusicSound")]
    private EventInstance _musicInstance;
    private EventReference _tempMusic;
    private int _musicIndex;

    [Header("EventSound")]
    private EventInstance _doorInstance;
    private EventReference _doorOpen;


    [Header("AudioRecorder")]
    private EventReference _audioRecorder_Play;
    private EventReference _audioRecorder_ChangeMusic;
    private Transform _soundRecorderPoint;

    [Header("TV")]
    private EventReference _tv_PickUp;
    private EventReference _tv_Install;
    private EventReference _tempGanre;
    private EventInstance _ganreInstance;
    private Transform _soundTvPoint;

    [Header("Present")]
    private EventReference _present_Drop;

    [Header("Garland")]
    private EventReference _garland_Active;

    [Header("Cassette")]
    private EventReference _scroll;
    private EventReference _pickUp;
    private EventReference _snapCorrect;
    private EventReference _snapWrong;
    private EventReference _drop;

    [Header("Phone")]
    private EventReference _phone_Down;
    private EventReference _phone_Up;
    private EventReference _ringPhone;
    private EventInstance _ringInstance;
    [Header("Cat")]
    private EventReference _cat_idle;
    private EventReference _cat_meow;
    private EventInstance _CatInstance;
    private Transform _soundCatPoint;


    public AudioManager(AudioSettings audioSettings, GroupEmitter groupEmitter)
    {
        _pickUp = audioSettings.PickUp;
        _snapCorrect = audioSettings.SnapCorrect;
        _snapWrong = audioSettings.SnapWrong;
        _drop = audioSettings.Drop;
        _ringPhone = audioSettings.Phone_Ring;
        _doorOpen = audioSettings.DoorOpen;
        _audioRecorder_Play = audioSettings.AudioRecorder_Play;
        _soundRecorderPoint = groupEmitter.SoundRecorderPoint;
        _audioRecorder_ChangeMusic = audioSettings.AudioRecorder_ChangeMusic;
        _tv_PickUp = audioSettings.Tv_PickUp;
        _tv_Install = audioSettings.Tv_Install;
        _present_Drop = audioSettings.Present_Drop;
        _scroll = audioSettings.Scroll;
        _phone_Down = audioSettings.Phone_Down;
        _phone_Up = audioSettings.Phone_Up;
        _soundTvPoint = groupEmitter.SoundTvPoint;
        _garland_Active = audioSettings.Garland_Active;
        _cat_idle = audioSettings.Cat_idle;
        _cat_meow = audioSettings.Cat_meow;
        _soundCatPoint = groupEmitter.SoundCatPoint;
    }

    public void Dispose()
    {
        StopSmartEvent(ref _voiceInstance);
        StopSmartEvent(ref _musicInstance);
        StopSmartEvent(ref _ringInstance);
        StopSmartEvent(ref _doorInstance);
    }

    public void PauseVoise(bool isPause)
    {
        if (CheckEvent(_voiceInstance))
        {
            _voiceInstance.setPaused(isPause);
        }

        if (CheckEvent(_ringInstance))
        {
            _ringInstance.setPaused(isPause);
        }

        if (CheckEvent(_doorInstance))
        {
            _doorInstance.setPaused(isPause);
        }
    }

    public void StopMusic()
    {
        StopSmartEvent(ref _musicInstance);
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

    public void SetTvGanre(EventReference eventReference)
    {
        _tempGanre = eventReference;
    }

    public void SetMusic(EventReference eventReference, int musicIndex)
    {
        Play(_audioRecorder_ChangeMusic);
        _tempMusic = eventReference;
        _musicIndex = musicIndex;
        StopSmartEvent(ref _musicInstance);
    }

    public void PlayVoice()
    {
        PlaySmartEvent(ref _tempVoice, ref _voiceInstance);
    }

    public void PlayTvGanre()
    {
        //PlaySmartEvent(ref _tempGanre, ref _ganreInstance);
        PlayPositionEvent(ref _tempGanre, ref _ganreInstance, _soundTvPoint.position);
        _ganreInstance.start();
    }

    public void PlayCatIdle()
    {
        PlayPositionEvent(ref _cat_idle, ref _CatInstance, _soundCatPoint.position);
        _CatInstance.start();
    }

    public void PlayCatMeow()
    {
        Play(_cat_meow);
    }

    public void PlayRing(Vector3 pos)
    {
        PlayPositionEvent(ref _ringPhone, ref _ringInstance, pos);
        _ringInstance.start();
    }

    public void PlayDoor(Vector3 pos)
    {
        PlayPositionEvent(ref _doorOpen, ref _doorInstance, pos);
        _doorInstance.start();
    }

    public void StopRing()
    {
        StopSmartEvent(ref _ringInstance);
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
            PlayPositionEvent(ref _tempMusic, ref _musicInstance, _soundRecorderPoint.position);
            _musicInstance.setParameterByName("MusicId", _musicIndex);
            _musicInstance.start();
        }
        Play(_audioRecorder_Play);
    }

    public void PlayTvInstall(bool isInstall)
    {
        if (isInstall)
        {
            Play(_tv_Install);
        }
        else
        {
            Play(_tv_PickUp);
        }
    }

    public void PlayPhoneInstall(bool isInstall)
    {
        if (isInstall)
        {
            Play(_phone_Up);
        }
        else
        {
            Play(_phone_Down);
        }
    }

    public void PlayPickUp()
    {
        Play(_pickUp);
    }

    public void PlayGarlandActive()
    {
        Play(_garland_Active);
    }

    public void PlayPresentDrop()
    {
        Play(_present_Drop);
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

    public void PlayScroll()
    {
        Play(_scroll);
    }

    public void StopVoice()
    {
        StopSmartEvent(ref _voiceInstance);
    }

    public void StopTvGanre()
    {
        StopSmartEvent(ref _ganreInstance);
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

    private void PlayPositionEvent(ref EventReference eventReference, ref EventInstance playHit, Vector3 Pos)
    {
        playHit = RuntimeManager.CreateInstance(eventReference); // Создаем событие Звука 

        playHit.set3DAttributes(RuntimeUtils.To3DAttributes(Pos)); // Мы вводим информацию об положении в 3Д , а                       
                                                                   //(RuntimeUtils.To3DAttributes) переводит наш Vector3 В понятный для Код 
                                                                   //playHit.start(); // Запускаем воспроизведение 
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
