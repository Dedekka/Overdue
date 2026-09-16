using System;
using Zenject;

public class ImporterAimSensitivity : IDisposable, IInitializable
{
    private PlayerAim _testPlayerAim;
    private PlayerLook _playerLook;
    private float _coefficientSensitivityAim;
    private readonly float _normalCoefficientSensitivityAim;

    public ImporterAimSensitivity(PlayerAim testPlayerAim, PlayerLook testPlayerLook, SettingsPlayer settingsPlayer)
    {
        _testPlayerAim = testPlayerAim;
        _playerLook = testPlayerLook;
        _normalCoefficientSensitivityAim = settingsPlayer.CoefficientSensitivityAim;
    }

    public void Dispose()
    {
        _testPlayerAim.OnAim -= OnAim;
    }

    public void Initialize()
    {
        _testPlayerAim.OnAim += OnAim;
    }

    private void OnAim(bool isAim)
    {
        _coefficientSensitivityAim = isAim ? _normalCoefficientSensitivityAim : 1;
        _playerLook.ChangeCoefficientSensitivityForAim(_coefficientSensitivityAim);
    }
}