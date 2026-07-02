using System;
using UnityEngine;
using Zenject;

public class ImporterInteractebleUI : IDisposable, IInitializable
{
    private PlayerUi _playerUi;
    //private SystemBuss _systemBuss;
    private PlayerInteracteble _playerInteracteble;

    public ImporterInteractebleUI(PlayerInteracteble playerInteracteble, PlayerUi playerUi)//SystemBuss systemBuss, 
    {
        //_systemBuss = systemBuss;
        _playerUi = playerUi;
        _playerInteracteble = playerInteracteble;
    }

    public void Dispose()
    {
        //_systemBuss.OnConstructPlayerUi -= OnConstructPlayerUi;
        _playerInteracteble.OnChangeCurrentInteracteble -= OnChangeCurrentInteracteble;
    }

    public void Initialize()
    {
        _playerInteracteble.OnChangeCurrentInteracteble += OnChangeCurrentInteracteble;
        //_systemBuss.OnConstructPlayerUi += OnConstructPlayerUi;
    }

    //private void OnConstructPlayerUi(PlayerUi playerUi)
    //{
    //    _playerUi = playerUi;
    //    _playerInteracteble.OnChangeCurrentInteracteble += OnChangeCurrentInteracteble;
    //}

    private void OnChangeCurrentInteracteble(string description)
    {
        _playerUi.UpdateText(description);
    }
}