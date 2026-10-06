using System;
using UnityEngine;
using Zenject;

public class ImporterInventoryPresentAudioManager : IDisposable, IInitializable
{
    private InventoryPresent _inventoryPresent;
    private AudioManager _audioManager;

    public ImporterInventoryPresentAudioManager(InventoryPresent inventoryPresent, AudioManager audioManager)
    {
        _inventoryPresent = inventoryPresent;
        _audioManager = audioManager;
    }

    public void Initialize()
    {
        _inventoryPresent.OnDrop += OnDrop;
    }

    public void Dispose()
    {
        _inventoryPresent.OnDrop -= OnDrop;
    }

    private void OnDrop()
    {
        _audioManager.PlayPresentDrop();
    }

   
}
