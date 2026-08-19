using System;
using Zenject;

public class ImporterTvManagerTV : IDisposable, IInitializable
{
    private TV _tv;
    private TvManager _tvManager;

    public ImporterTvManagerTV(TV tv, TvManager tvManager)
    {
        _tv = tv;
        _tvManager = tvManager;
    }

    public void Initialize()
    {
        _tvManager.OnPlayEpisode += OnPlayEpisode;
    }

    public void Dispose()
    {
        _tvManager.OnPlayEpisode -= OnPlayEpisode;
    }

    private void OnPlayEpisode(bool isplay)
    {
        //_tv.ActiveSlot(!isplay);
    }
}