using DG.Tweening;
using UnityEngine;

public class LookItemRotate
{
    [SerializeField] private Transform _slotLookItem;
    private float _sensitivityY;
    private float _sensitivityX;
    private float _sensitivity;
    private float _coefficientGamepadSensitivity;
    private float _xRotation;
    private float _yRotation;
    private bool _isActive;

    public LookItemRotate(SettingsLookItem settingsLookItem, Transform lookItemPos)
    {
        _slotLookItem = lookItemPos;
        _sensitivityY = settingsLookItem.SensitivityRotateItemY;
        _sensitivityX = settingsLookItem.SensitivityRotateItemX;
        _sensitivity = settingsLookItem.MainSensitivityRotateItem;
        _coefficientGamepadSensitivity = settingsLookItem.CoefficientGamepadSensitivity;
        _xRotation = 0;
        _yRotation = 0;
    }
    
    public void ActiveRotate(bool isActive)
    {
        _isActive = isActive;
    }
    
    public void ProcessRotate(Vector2 rotate, DeviceType deviceType)
    {
        if (!_isActive) { return; }

        float mouseX = rotate.x;
        float mouseY = rotate.y;

        CheckDevice(ref mouseX, ref mouseY, deviceType);

        _xRotation -= mouseY * _sensitivityY;
        _yRotation -= mouseX * _sensitivityX;
        _slotLookItem.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }

    public void ResetLookItemRotate()
    {
        ActiveRotate(false);
        _xRotation = 0;
        _yRotation = 0;
        _slotLookItem.DOLocalRotate(Vector3.zero, 1f)
            .OnComplete(() => ActiveRotate(true))
            .Play();
    }

    private void CheckDevice(ref float mouseX, ref float mouseY, DeviceType deviceType)
    {
        if (deviceType == DeviceType.KeyboardMouse)
        {
            mouseX *=  _sensitivity;
            mouseY *=   _sensitivity;
        }
        else
        {
            mouseX *=  _coefficientGamepadSensitivity;
            mouseY *=  _coefficientGamepadSensitivity;
        }
    }
}