using FMODUnity;
using System;
using UnityEngine;


public class MusicControl
{
    private MusicCassetteSettings _currentMusicCassetteSettings;
    private DataMusicCassets _dataMusicCassets;
    private EventReference _tempMusic;

    private bool _isPlaying;

    public event Action<EventReference,int> OnChangeMusic;

    public event Action<bool> OnChangeState;

    public MusicControl(DataMusicCassets dataMusicCassets)
    {
        _dataMusicCassets = dataMusicCassets;
        _isPlaying = false;
    }

    public void SetMusic(int idMusic)
    {
        _currentMusicCassetteSettings = _dataMusicCassets.GetItem(idMusic);
        SetFmodSound();
    }

    public void PlayMusic()
    {
        Debug.Log("MusicControl_PRE_PlayMusic");
        if (_currentMusicCassetteSettings == null) { return; }
        Debug.Log("MusicControl_POST_PlayMusic");
        ChangePlaying();
        OnChangeState?.Invoke(_isPlaying);
    }

    private void SetFmodSound()
    {
        if (_currentMusicCassetteSettings != null)
        {
            string audioPath = _currentMusicCassetteSettings.Audio;
            int musicIndex = _currentMusicCassetteSettings.MusicIndex;

            _tempMusic = RuntimeManager.PathToEventReference(audioPath);
            _isPlaying = false;
            OnChangeMusic?.Invoke(_tempMusic, musicIndex);
        }
        else
        {
            Debug.LogError("Not Found SetFmodSound Music");
        }
    }

    private void ChangePlaying()
    {
        _isPlaying = !_isPlaying;
        Debug.Log($"ChangePlaying: {_isPlaying}");
    }
}