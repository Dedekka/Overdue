using System;
using UnityEngine;
using Zenject;

public class ImporterTvManagerPlayer : IDisposable, IInitializable
{
    private TvManager _tv;
    private Player _player;

    public ImporterTvManagerPlayer(TvManager tv, Player player)
    {
        _tv = tv;
        _player = player;
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
        _player.gameObject.SetActive(!isVisible);
    }
}
