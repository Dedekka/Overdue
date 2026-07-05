using System;
using Zenject;

public class ImporterInteractebleUI : IDisposable, IInitializable
{
    private PlayerUi _playerUi;
    private PlayerInteracteble _playerInteracteble;

    public ImporterInteractebleUI(PlayerInteracteble playerInteracteble, PlayerUi playerUi)//SystemBuss systemBuss, 
    {
        _playerUi = playerUi;
        _playerInteracteble = playerInteracteble;
    }

    public void Dispose()
    {
        _playerInteracteble.OnChangeCurrentInteracteble -= OnChangeCurrentInteracteble;
    }

    public void Initialize()
    {
        _playerInteracteble.OnChangeCurrentInteracteble += OnChangeCurrentInteracteble;
    }

    private void OnChangeCurrentInteracteble(string description)
    {
        _playerUi.UpdateText(description);
    }
}