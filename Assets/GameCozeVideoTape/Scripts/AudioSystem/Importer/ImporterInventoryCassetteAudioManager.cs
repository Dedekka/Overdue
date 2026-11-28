using System;
using UnityEngine;
using Zenject;

public class ImporterInventoryCassetteAudioManager : IDisposable, IInitializable
{
    private InventoryCassette _inventoryPresent;
    private AudioManager _audioManager;
    private float _timeWait;
    private float _timeWaitScrollSound;

    public ImporterInventoryCassetteAudioManager(InventoryCassette inventoryPresent, AudioManager audioManager, AudioSettings audioSettings)
    {
        _inventoryPresent = inventoryPresent;
        _audioManager = audioManager;
        _timeWait = 0;
        _timeWaitScrollSound = audioSettings.TimeWaitScrollSound;
    }

    public void Initialize()
    {
        _inventoryPresent.OnScroll += OnScroll;
    }

    public void Dispose()
    {
        _inventoryPresent.OnScroll -= OnScroll;
    }

    private void OnScroll()
    {
        if (Time.time > _timeWait)
        {
            _timeWait = Time.time + _timeWaitScrollSound;
            _audioManager.PlayScroll();
        }
    }
}