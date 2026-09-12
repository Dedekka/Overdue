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
    private ControlGenreVideo _controlGenreVideo;

    //private DataOpera _dataOpera;

    private OperaSettings _currentEpisode;
    private GenreVideo _currentGanreVideo;

    public event Action<bool> OnPlayEpisode;

    public TvManager(DialogSubtitles dialogSubtitles, VideoControl videoControl, TVCameraControl tvCameraControl, DialogSound dialogSound, OperaChecker operaChecker, ControlGenreVideo controlGenreVideo)//, DataOpera dataOpera)
    {
        _dialogSubtitles = dialogSubtitles;
        _videoControl = videoControl;
        _tvCameraControl = tvCameraControl;
        _dialogSound = dialogSound;
        _operaChecker = operaChecker;
        _controlGenreVideo = controlGenreVideo;
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

    public void OnPlayCasset()
    {
        bool isCorrectEpisode = CheckEpisode();
        if (isCorrectEpisode)
        {
            bool successStartDialog = _dialogSubtitles.StartWaitSubtitles(_currentEpisode);
            CheckSuccessCall(successStartDialog);
        }
        else
        {
            // Запустить жанровое видео
            StartGanreVideo();
        }
    }

    public void StopPlay()
    {
        _videoControl.StopVideo();
        _dialogSound.StopSound();
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

    private void StartGanreVideo()
    {
        SetEpisode(_currentGanreVideo.Video, _currentGanreVideo.Audio);
        PlayGanreVideo();
    }



    private bool CheckEpisode()
    {
        bool isOpera;

        _currentEpisode = _operaChecker.GetOperaEpisode();
        isOpera = _currentEpisode != null;

        if (!isOpera)
        {
            _currentGanreVideo = _controlGenreVideo.GetGenreVideo();
        }


        //_currentEpisode = _dataOpera.GetOperaSettings(idEpisode);
        return isOpera;
    }

    private void SetEpisode()
    {
        _videoControl.SetVideo();
        _dialogSound.SetFmodSound(_currentEpisode.Audio);
    }

    private void SetEpisode(VideoClip video, string Audio)
    {
        _videoControl.SetVideo(video);
        _dialogSound.SetFmodSound(Audio);
    }

    private void PlayGanreVideo()
    {
        _videoControl.StartEpisode();
        _dialogSound.StartSound();
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