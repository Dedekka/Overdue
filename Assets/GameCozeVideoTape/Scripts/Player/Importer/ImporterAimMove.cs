using System;
using Zenject;

public class ImporterAimMove : IDisposable, IInitializable
{
    private PlayerAim _testPlayerAim;
    private PlayerMove _testPlayerMove;
    private float _coefficientSpeedForAim;
    private readonly float _normalCoefficientSpeedForAim;

    public ImporterAimMove(PlayerAim testPlayerAim, PlayerMove testPlayerMove, SettingsPlayer settingsPlayer)
    {
        _testPlayerAim = testPlayerAim;
        _testPlayerMove = testPlayerMove;
        _normalCoefficientSpeedForAim = settingsPlayer.CoefficientSpeedMoveForAim;
    }

    public void Dispose()
    {
        _testPlayerAim.OnAim -= OnAim;
    }

    public void Initialize()
    {
        _coefficientSpeedForAim = 1;
        _testPlayerAim.OnAim += OnAim;
    }

    private void OnAim(bool isAim)
    {
        _coefficientSpeedForAim = isAim ? _normalCoefficientSpeedForAim : 1;
        _testPlayerMove.ChangeCoefficientSpeedForAim(_coefficientSpeedForAim);
    }
}