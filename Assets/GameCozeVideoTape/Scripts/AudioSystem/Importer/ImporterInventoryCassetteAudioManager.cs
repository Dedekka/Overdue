using System;
using UnityEngine;
using Zenject;

public class ImporterInventoryCassetteAudioManager : IDisposable, IInitializable
{
    private InventoryCassette _inventoryPresent;
    private AudioManager _audioManager;

    public ImporterInventoryCassetteAudioManager(InventoryCassette inventoryPresent, AudioManager audioManager)
    {
        _inventoryPresent = inventoryPresent;
        _audioManager = audioManager;
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
        _audioManager.PlayScroll();
    }

}
