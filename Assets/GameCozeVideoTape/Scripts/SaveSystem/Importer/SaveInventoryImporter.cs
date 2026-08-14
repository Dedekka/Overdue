using SaveLoadSystem;
using System;
using Zenject;

public class SaveInventoryImporter : IDisposable, IInitializable
{
    private PlayerInventory _playerInventory;
    private Saver _saver;

    public SaveInventoryImporter(PlayerInventory playerInventory, Saver saver)
    {
        _playerInventory = playerInventory;
        _saver = saver;
    }

    public void Initialize()
    {
        _saver.OnLoad += OnLoad;
        //_saver.OnSave += OnSave;
    }

    public void Dispose()
    {
        _saver.OnLoad -= OnLoad;
        //_saver.OnSave -= OnSave;
    }

    //private void OnSave()
    //{

    //}

    private void OnLoad()
    {
        _playerInventory.DropAllCassette();
    }
}
