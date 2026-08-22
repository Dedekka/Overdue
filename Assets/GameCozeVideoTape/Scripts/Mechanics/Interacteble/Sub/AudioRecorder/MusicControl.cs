using FMODUnity;
using System;
using UnityEngine;


public class MusicControl
{
    private MusicCassetteSettings _currentMusicCassetteSettings;
    private DataMusicCassets _dataMusicCassets;
    private EventReference _tempMusic;

    public event Action<EventReference> OnChangeMusic;

    public event Action<bool> OnChangeState;

    public MusicControl(DataMusicCassets dataMusicCassets)
    {
        _dataMusicCassets = dataMusicCassets;
    }

    public void SetMusic(int idMusic)
    {
        _currentMusicCassetteSettings = _dataMusicCassets.GetItem(idMusic);
        string audioPath = _currentMusicCassetteSettings == null ? null : _currentMusicCassetteSettings.Audio;
        SetFmodSound(audioPath);
    }

    public void PlayMusic(bool _isPlaying)
    {
        if (_currentMusicCassetteSettings == null) { return; }
        OnChangeState?.Invoke(_isPlaying);
    }

    private void SetFmodSound(string audioPath)
    {
        if (audioPath != null)
        {
            _tempMusic = RuntimeManager.PathToEventReference(audioPath);
            OnChangeMusic?.Invoke(_tempMusic);
        }
        else
        {
            Debug.LogError("Not Found SetFmodSound Music");
        }
    }
}