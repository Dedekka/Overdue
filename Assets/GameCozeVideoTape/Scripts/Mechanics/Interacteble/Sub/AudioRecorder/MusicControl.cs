using FMODUnity;
using System;
using UnityEngine;


public class MusicControl
{
    private MusicCassetteSettings _currentMusicCassetteSettings;
    private DataMusicCassets _dataMusicCassets;
    private EventReference _tempMusic;

    private bool _isPlaying;

    public event Action<EventReference> OnChangeMusic;

    public event Action<bool> OnChangeState;

    public MusicControl(DataMusicCassets dataMusicCassets)
    {
        _dataMusicCassets = dataMusicCassets;
        _isPlaying = false;
    }

    public void SetMusic(int idMusic)
    {
        _currentMusicCassetteSettings = _dataMusicCassets.GetItem(idMusic);
        string audioPath = _currentMusicCassetteSettings == null ? null : _currentMusicCassetteSettings.Audio;
        SetFmodSound(audioPath);
    }

    public void PlayMusic()
    {
        Debug.Log("MusicControl_PRE_PlayMusic");
        if (_currentMusicCassetteSettings == null) { return; }
        Debug.Log("MusicControl_POST_PlayMusic");
        ChangePlaying();
        OnChangeState?.Invoke(_isPlaying);
    }

    private void SetFmodSound(string audioPath)
    {
        if (audioPath != null)
        {
            Debug.Log($"MusicControl_ SetFmodSound, audioPath:{audioPath}");
            _tempMusic = RuntimeManager.PathToEventReference(audioPath);
            _isPlaying = false;
            OnChangeMusic?.Invoke(_tempMusic);
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