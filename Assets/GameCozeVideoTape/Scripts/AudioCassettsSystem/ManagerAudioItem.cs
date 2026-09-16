using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManagerAudioItem : IInitializable, IDisposable
{
    private List<AudioItem> _audioItems;
    private AudioItemRenderer _audioItemRenderer;
    private DataMusicCassets _dataMusicCassets;
    //private DataMusicLanguage _dataMusicLanguage;
    private ControlMusicLanguage _controlMusicLanguage;

    private int _maxAudioItem;

    public ManagerAudioItem(AudioItemRenderer audioItemRenderer, int maxAudioItem, DataMusicCassets dataMusicCassets, ControlMusicLanguage controlMusicLanguage)
    {
        _audioItemRenderer = audioItemRenderer;
        _maxAudioItem = maxAudioItem * 2;
        _audioItems = new List<AudioItem>();
        _dataMusicCassets = dataMusicCassets;
        _controlMusicLanguage = controlMusicLanguage;
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

    public void ChangeLanguage()
    {
        _controlMusicLanguage.GetLanguage(_audioItems);
    }

    private void CheckMaxAudioItem()
    {
        Debug.Log($"ManagerAudioItem_CheckMaxAudioItem, _audioItems:{_audioItems.Count} , _maxAudioItem: {_maxAudioItem} ");
        if (_audioItems.Count == _maxAudioItem)
        {
            Debug.Log($"FIn , _audioItems:{_audioItems.Count} , _maxAudioItem: {_maxAudioItem} ");
            _dataMusicCassets.GetSettings(_audioItems);
            _controlMusicLanguage.GetLanguage(_audioItems);
            //_audioItemRenderer.SetCassette(_audioItems);
        }
    }
}