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
        _playerInteracteble.OnShowPanelUse -= OnShowPanelUse;
    }

    public void Initialize()
    {
        _playerInteracteble.OnChangeCurrentInteracteble += OnChangeCurrentInteracteble;
        _playerInteracteble.OnShowPanelUse += OnShowPanelUse;
    }

    private void OnChangeCurrentInteracteble(string description)
    {
        _playerUi.UpdateTextDescription(description);
    }

    private void OnShowPanelUse(bool isShowPanelUse)
    {
        _playerUi.ShowPanelUse(isShowPanelUse);
    }
}