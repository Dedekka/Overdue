using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlGamepadVibration : IDisposable
{
    private GamepadSettings _gamepadSettings;
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;
    private CancellationTokenSource _cancellationTokenSource;
    private Gamepad _gamepad;
    private Vector2 _forceVibrationPresent;
    private Vector2 _forceVibrationInstall;
    private Vector2 _forceVibrationInstallFail;
    private readonly float _durationVibrationPresent;
    private readonly float _durationVibrationInstall;
    private readonly float _durationVibrationInstallFail;

    public ControlGamepadVibration(GamepadSettings gamepadSettings, ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
        _gamepadSettings = gamepadSettings;
        _forceVibrationInstall = gamepadSettings.ForceVibrationInstallSuccess;
        _forceVibrationInstallFail = gamepadSettings.ForceVibrationInstallFail;
        _forceVibrationPresent = _gamepadSettings.ForceVibrationPresent;
        _durationVibrationPresent = _gamepadSettings.DurationVibrationPresent;
        _durationVibrationInstall = _gamepadSettings.DurationVibrationInstallSuccess;
        _durationVibrationInstallFail = _gamepadSettings.DurationVibrationInstallFail;
    }

    public void Dispose()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
    }

    public void PauseVibration(bool isPause)
    {
        if (!CheckActiveGamepad()) { return; }
        if (isPause)
        {
            _gamepad.PauseHaptics();
        }
        else
        {
            _gamepad.ResumeHaptics();
        }
    }

    public void ActiveVibrationPhone(float _forceVibration)
    {
        Debug.Log($"ActiveVibrationPhone, _forceVibration:{_forceVibration}");
        if (!CheckActiveGamepad()) { return; }
        _forceVibration = _forceVibration > _gamepadSettings.MaxForceVibration ? _gamepadSettings.MaxForceVibration : _forceVibration;

        _gamepad.SetMotorSpeeds(_forceVibration, _forceVibration);
        Debug.Log($"ActiveVibrationPhone, SetMotorSpeeds:{_forceVibration}");
    }

    public void ResetVibration()
    {
        if (!CheckActiveGamepad()) { return; }
        _gamepad.ResetHaptics();
    }

    public void ActiveVibrationPresent()
    {
        Dispose();
        if (!CheckActiveGamepad()) { return; }
        _gamepad.SetMotorSpeeds(_forceVibrationPresent.x, _forceVibrationPresent.y);
    }

    public void ActiveVibrationInstall(bool isState)
    {
        Dispose();
        if (!CheckActiveGamepad()) { return; }
        _cancellationTokenSource = new CancellationTokenSource();
        if (isState)
        {

            ControlVibration(_cancellationTokenSource.Token, _forceVibrationInstall, _durationVibrationInstall).Forget();
        }
        else
        {
            ControlVibration(_cancellationTokenSource.Token, _forceVibrationInstallFail, _durationVibrationInstallFail).Forget();
        }
    }

    private async UniTask ControlVibration(CancellationToken token, Vector2 forceVibration, float durationVibration)
    {
        if (!CheckActiveGamepad()) { return; }
        try
        {
            _gamepad.SetMotorSpeeds(forceVibration.x, forceVibration.y);
            await UniTask.Delay(TimeSpan.FromSeconds(durationVibration), cancellationToken: token);
        }
        finally
        {
            _gamepad.ResetHaptics();
        }
    }

    private bool CheckActiveGamepad()
    {
        bool isGamepadSelected = false;
        if (_importerMenuInputControlDevice.Device is Gamepad gamepad)
        {
            _gamepad = gamepad;
            isGamepadSelected = true;
        }
        return isGamepadSelected;
    }
}