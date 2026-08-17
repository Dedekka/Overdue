using SaveLoadSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManagerCassette : IInitializable, IDisposable
{
    public Dictionary<int, CassetteObject> CassetsDictionary => _cassetsDictionary;
    private List<CassetteObject> _listCassette;
    private Dictionary<int, CassetteObject> _cassetsDictionary;
    private ControlSleepCassette _controlSleepCassette;
    private CassetteHolder _cassetteHolder;
    private DataCassets _dataCassets;
    private AudioCassette _audioCassette;
    private CassetteRenderer _cassetteRenderer;
    //private DataLanguage _dataLanguage;
    private InventoryCassette _inventorySlot;
    private int _maxCassette;

    public ManagerCassette(DataCassets dataCassets, CassetteHolder cassetteHolder, ControlSleepCassette controlSleepCassette, InventoryCassette inventorySlot, AudioCassette audioCassette, CassetteRenderer cassetteRenderer, int maxCassette)//DataLanguage dataLanguage,
    {
        _maxCassette = maxCassette;
        _audioCassette = audioCassette;
        _controlSleepCassette = controlSleepCassette;
        _dataCassets = dataCassets;
        //_dataLanguage = dataLanguage;
        _cassetteHolder = cassetteHolder;
        _inventorySlot = inventorySlot;
        _cassetteRenderer = cassetteRenderer;
        _listCassette = new List<CassetteObject>();
    }

    public void Initialize()
    {
        _cassetteHolder.OnSave += Save;
        _cassetteHolder.OnUpdateItems += UpdateItems;
    }

    public void Dispose()
    {
        _cassetteHolder.OnSave -= Save;
        _cassetteHolder.OnUpdateItems -= UpdateItems;
        _audioCassette.UnSubAudio(_listCassette);
    }

    public void AddCassette(CassetteObject cassetteObject)
    {
        _listCassette.Add(cassetteObject);
        CheckMaxCassetteObject();
    }

    public ItemSettings GetSettings(int Id)
    {
        return _dataCassets.GetItem(Id);
    }

    private void CheckMaxCassetteObject()
    {
        //_maxCassette = _maxCassette > 0 ? _maxCassette : _dataCassets.GetMaxCassette();

        if (_listCassette.Count == _maxCassette)
        {
            Debug.Log($"END: _listCassette.Count = {_listCassette.Count} ,_maxCassette = {_maxCassette} ");
            _dataCassets.GetSettings(_listCassette);
            SetDictionary();
            _cassetteHolder.AddCassette(_listCassette, _inventorySlot.GetActiveCassets());
            _controlSleepCassette.SetCassette(_listCassette);
            _audioCassette.SubAudio(_listCassette);
            _cassetteRenderer.SetCassette(_listCassette);
        }
    }

    private void UpdateItems()
    {
        _cassetteHolder.SetUpdate(_listCassette);
        _cassetteHolder.SetHandUpdate(_cassetsDictionary);
    }

    private void Save()
    {
        _cassetteHolder.AddCassette(_listCassette, _inventorySlot.GetActiveCassets());
    }

    private void SetDictionary()
    {
        _cassetsDictionary = new Dictionary<int, CassetteObject>();

        for (int i = 0; i < _listCassette.Count; i++)
        {
            _cassetsDictionary.Add(_listCassette[i].Id, _listCassette[i]);
        }
    }
}