using UnityEngine;

public class PlayerLook
{
    private Transform _headSlot;
    private Transform _body;
    private float _sensitivityY;
    private float _sensitivityX;
    private float _sensitivity;
    private float _xRotation;
    private float _coefficientSensitivityAim;
    private float _coefficientGamepadSensitivity;
    
    public PlayerLook(SettingsPlayer settingsPlayer, Transform headSlot, Transform body)
    {
        _headSlot = headSlot;
        _body = body;
        _sensitivityY = settingsPlayer.SensitivityY;
        _sensitivityX = settingsPlayer.SensitivityX;
        _coefficientGamepadSensitivity = settingsPlayer.CoefficientGamepadSensitivity;
        _coefficientSensitivityAim = 1;
        _xRotation = _headSlot.transform.localRotation.eulerAngles.x;
        _sensitivity = settingsPlayer.MainSensitivity;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ProcessLook(Vector2 vector2, DeviceType deviceType)
    {
        float mouseX = vector2.x;
        float mouseY = vector2.y;

        CheckDevice(ref mouseX, ref mouseY, deviceType);
        _xRotation -= mouseY * _sensitivityY;// * _sensitivity;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        _headSlot.transform.localRotation = Quaternion.Euler(_xRotation, 0, 0);
        _body.Rotate(mouseX * _sensitivityX * Vector3.up); // * _sensitivity);
    }

    /// <summary>
    /// Для изменения чувствительности во время прицеливания
    /// </summary>
    /// <param name="coefficientSpeed"></param>
    public void ChangeCoefficientSensitivityForAim(float coefficientSpeed)
    {
        ChangeCoefficientSpeed(ref _coefficientSensitivityAim, coefficientSpeed);
    }

    /// <summary>
    /// Для изменения чувствительности через настройки
    /// </summary>
    /// <param name="coefficientSpeed"></param>
    public void ChangeSensitivity(float coefficientSpeed)
    {
        ChangeCoefficientSpeed(ref _sensitivity, coefficientSpeed);
    }

    private void ChangeCoefficientSpeed(ref float coefficient, float tempCoefficientSpeed)
    {
        tempCoefficientSpeed = Mathf.Abs(tempCoefficientSpeed);
        coefficient = tempCoefficientSpeed > 1 ? 1 : tempCoefficientSpeed;
    }

    private void CheckDevice(ref float mouseX, ref float mouseY, DeviceType deviceType)
    {
        if (deviceType == DeviceType.KeyboardMouse)
        {
        mouseX *= _coefficientSensitivityAim * _sensitivity;
        mouseY *= _coefficientSensitivityAim * _sensitivity;
        }
        else
        {
            mouseX *= _coefficientSensitivityAim * _sensitivity * _coefficientGamepadSensitivity;
            mouseY *= _coefficientSensitivityAim * _sensitivity * _coefficientGamepadSensitivity;
        }
    }
}