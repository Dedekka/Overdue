using System;
using UnityEngine;
using Zenject;

public class ImporterPlayerUiTvManager : IDisposable, IInitializable
{
    private TvManager _tv;
    private PlayerUi _playerUi;

    public ImporterPlayerUiTvManager(TvManager tv, PlayerUi playerUi)
    {
        _tv = tv;
        _playerUi = playerUi;
    }

    public void Initialize()
    {
        _tv.OnPlayEpisode += OnPlayEpisode;
    }

    public void Dispose()
    {
        _tv.OnPlayEpisode -= OnPlayEpisode;
    }

    private void OnPlayEpisode(bool isVisible)
    {
        _playerUi.ChangeOtherGoup(!isVisible);
    }
}
