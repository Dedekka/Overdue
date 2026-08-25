using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using Zenject;

public class ManagerAudioItem : IInitializable, IDisposable
{
    private List<AudioItem> _audioItems;
    private AudioItemRenderer _audioItemRenderer;
    private DataMusicCassets _dataMusicCassets;

    private int _maxAudioItem;

    public ManagerAudioItem(AudioItemRenderer audioItemRenderer , int maxAudioItem, DataMusicCassets dataMusicCassets)
    {
        _audioItemRenderer = audioItemRenderer;
        _maxAudioItem = maxAudioItem * 2;
        _audioItems = new List<AudioItem>();
        _dataMusicCassets = dataMusicCassets;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Initialize()
    {
        throw new NotImplementedException();
    }

    public void AddAudioItem(AudioItem audioItem)
    {
        _audioItems.Add(audioItem);
        CheckMaxAudioItem();
    }

    private void CheckMaxAudioItem()
    {
        Debug.Log($"ManagerAudioItem_CheckMaxAudioItem, _audioItems:{_audioItems.Count} , _maxAudioItem: {_maxAudioItem} ");
        if (_audioItems.Count == _maxAudioItem)
        {
        Debug.Log($"FIn , _audioItems:{_audioItems.Count} , _maxAudioItem: {_maxAudioItem} ");
            _audioItemRenderer.SetCassette(_audioItems);
        }
    }
}