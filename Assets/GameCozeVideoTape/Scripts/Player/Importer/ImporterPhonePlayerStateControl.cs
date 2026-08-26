using System;
using UnityEngine;
using Zenject;

public class ImporterPhonePlayerStateControl : IDisposable, IInitializable
{
    private Phone _phone;
    private TvManager _tvManager;
    private PlayerStateControl _playerStateControl;

    public ImporterPhonePlayerStateControl(Phone phone, PlayerStateControl playerStateControl, TvManager tvManager)
    {
        _phone = phone;
        _playerStateControl = playerStateControl;
        _tvManager = tvManager;
    }

    public void Initialize()
    {
        _phone.OnStartCall += OnStartCall;
        _tvManager.OnPlayEpisode += OnPlayEpisode;
    }

    public void Dispose()
    {
        _tvManager.OnPlayEpisode -= OnPlayEpisode;
        _phone.OnStartCall -= OnStartCall;
    }

    private void OnPlayEpisode(bool isPlay)
    {
        Debug.Log($"OnPlayEpisode_ImporterPhonePlayerStateControl, isPlay:{isPlay}");
        _playerStateControl.ChangeStateControlPlayer(!isPlay);
    }

    private void OnStartCall()
    {
        _playerStateControl.ChangeStateControlPlayer(false);
    }
}
