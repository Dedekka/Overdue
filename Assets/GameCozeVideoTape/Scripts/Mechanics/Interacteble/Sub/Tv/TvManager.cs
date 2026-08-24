using System;
using UnityEngine;
using UnityEngine.Video;
using Zenject;

public class TvManager : IDisposable, IInitializable
{
    private DialogSubtitles _dialogSubtitles;
    private VideoControl _videoControl;
    private TVCameraControl _tvCameraControl;
    private DialogSound _dialogSound;
    private OperaChecker _operaChecker;
    //private DataOpera _dataOpera;

    private OperaSettings _currentEpisode;

    public event Action<bool> OnPlayEpisode;

    public TvManager(DialogSubtitles dialogSubtitles, VideoControl videoControl, TVCameraControl tvCameraControl, DialogSound dialogSound, OperaChecker operaChecker)//, DataOpera dataOpera)
    {
        _dialogSubtitles = dialogSubtitles;
        _videoControl = videoControl;
        _tvCameraControl = tvCameraControl;
        _dialogSound = dialogSound;
        _operaChecker = operaChecker;
        //_dataOpera = dataOpera;
    }
    
    public void Initialize()
    {
        _videoControl.ClearVideo();
        _videoControl.OnEndEpisode += OnEndEpisode;
    }


    public void Dispose()
    {
        _videoControl.OnEndEpisode -= OnEndEpisode;
    }

    public void Initialization(VideoPlayer videoPlayer)
    {
        _videoControl.Initialization(videoPlayer);
    }

    public void OnPlayCasset(int currentIdOpera)
    {
        
        bool isCorrectEpisode = CheckEpisode(currentIdOpera);
        if (isCorrectEpisode)
        {
            bool successStartDialog = _dialogSubtitles.StartWaitSubtitles(_currentEpisode);
            CheckSuccessCall(successStartDialog);
        }
    }

    private void OnEndEpisode()
    {
        _videoControl.ClearVideo();
        _tvCameraControl.EndEpisode();
        OnPlayEpisode?.Invoke(false);
    }


    private void CheckSuccessCall(bool successStartDialog)
    {
        if (successStartDialog)
        {
            StartEpisode();
        }
    }

    private void StartEpisode()
    {
        SetEpisode();
        PlayEpisode();
    }

    private bool CheckEpisode(int idEpisode)
    {
        _operaChecker.CheckEpisode(idEpisode);
        _currentEpisode = _operaChecker.GetOperaEpisode();
        //_currentEpisode = _dataOpera.GetOperaSettings(idEpisode);
        return _currentEpisode != null;
    }

    private void SetEpisode()
    {
        _videoControl.SetVideo(_currentEpisode);
        _dialogSound.SetFmodSound(_currentEpisode.Audio);
    }

    private void PlayEpisode()
    {
        Debug.Log("PlayEpisode");
        OnPlayEpisode?.Invoke(true);
        _videoControl.StartEpisode();
        _tvCameraControl.StartEpisode();
        _dialogSound.StartSound();
    }
}