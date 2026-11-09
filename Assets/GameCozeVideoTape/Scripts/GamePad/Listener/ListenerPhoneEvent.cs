using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class ListenerPhoneEvent : IDisposable, IInitializable
{
    private CancellationTokenSource _tokenSource;
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;
    private ControlGamepadVibration _controlGamepadVibration;
    private PhoneEffect _phoneEffect;
    private GamepadSettings _gamepadSettings;

    private Phone _phone;
    private Player _player;
    private float _rangeVibrationPhone;
    private float _tempForce;
    private float _timeWaitVibration;
    //private float _tempTimeWait;
    //private float _tempTimeWaitWaiting;
    private float _timeWaitWaiting;
    private bool _isPlaying;
    private bool _isWaitRing;


    public ListenerPhoneEvent(PhoneEffect phoneEffect, ControlGamepadVibration controlGamepadVibration, ImporterMenuInputControlDevice importerMenuInputControlDevice, Phone phone, Player player, GamepadSettings gamepadSettings)
    {
        _timeWaitWaiting = gamepadSettings.TimeWaitWaiting;
        _timeWaitVibration = gamepadSettings.TimeVibration;
        _rangeVibrationPhone = gamepadSettings.RangeVibrationPhone;
        _gamepadSettings = gamepadSettings;
        _controlGamepadVibration = controlGamepadVibration;
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
        _phoneEffect = phoneEffect;
        _phone = phone;
        _player = player;
        _isPlaying = false;
        _isWaitRing = false;
    }

    public void Initialize()
    {
        _phoneEffect.OnRingEffect += OnRingEffect;
    }

    public void Dispose()
    {
        _phoneEffect.OnRingEffect -= OnRingEffect;
    }

    private void OnRingEffect(bool isState)
    {
        if (_importerMenuInputControlDevice.Device is Gamepad gamepad)
        {
            if (_isPlaying == isState) { return; }
            _isPlaying = isState;
            ClearTask();
            _tokenSource = new CancellationTokenSource();

            if (isState)
            {
                ActiveRingEffect(_tokenSource.Token);
            }
            else
            {
                _controlGamepadVibration.ResetVibration();
            }
        }
    }

    private void ActiveRingEffect(CancellationToken token)
    {
        WaitPickUpPhone(token).Forget();
        ChangePhoneVibration(token).Forget();
    }

    private async UniTask WaitPickUpPhone(CancellationToken token)
    {
        while (_isPlaying)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);
            _tempForce = CheckForce();
            if (_isWaitRing)
            {
                _controlGamepadVibration.ActiveVibrationPhone(_tempForce);
            }
            else
            {
                _controlGamepadVibration.ActiveVibrationPhone(0);
            }

        }
        _tempForce = 0;
        _controlGamepadVibration.ResetVibration();
    }
    // 1 сек звонить 1.5 молчит

    private async UniTask ChangePhoneVibration(CancellationToken token)
    {
        while (_isPlaying)
        {
            Debug.Log($"ChangePhoneVibration, tempForce:{_tempForce}");
            //_controlGamepadVibration.ActiveVibrationPhone(_tempForce);
            _isWaitRing = true;
            await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitVibration), cancellationToken: token);
            //_controlGamepadVibration.ActiveVibrationPhone(0);
            _isWaitRing = false;
            await UniTask.Delay(TimeSpan.FromSeconds(_timeWaitWaiting), cancellationToken: token);
        }
    }

    private float CheckForce()
    {
        //bool isReadyWait = false;
        float distance = Vector3.Distance(_phone.transform.position, _player.transform.position);
        distance = distance > _rangeVibrationPhone ? _rangeVibrationPhone : distance;

        float tempForce = distance / _rangeVibrationPhone;
        tempForce = 1 - tempForce;
        Debug.Log($"CheckForce, tempForce:{tempForce}");
        return tempForce;
        // Если время + переменная больше чем время то вибрация активна 

        // Если меньше условие 2 если то время 

        //if (Time.time < _tempTimeWait)
        //{
        //    isReadyWait = true;
        //    tempForce = 0;
        //}

        //if (Time.time < _tempTimeWaitWaiting)
        //{
        //    _tempTimeWait = isReadyWait?  Time.time + _timeWaitVibration : _tempTimeWait;
        //    _tempTimeWaitWaiting = Time.time + _timeWaitWaiting;
        //}
        //else
        //{
        //    _tempTimeWait = Time.time + _timeWaitVibration;
        //}
        //_controlGamepadVibration.ActiveVibrationPhone(tempForce);
    }

    private void ClearTask()
    {
        _tokenSource?.Cancel();
        _tokenSource?.Dispose();
    }
}