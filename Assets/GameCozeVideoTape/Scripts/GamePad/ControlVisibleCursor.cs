using System;
using UnityEngine;
using Zenject;

public class ControlVisibleCursor : IDisposable, IInitializable
{
    private ImporterMenuInputControlDevice _importerMenuInputControlDevice;
    private bool _isVisibleState;

    public ControlVisibleCursor(ImporterMenuInputControlDevice importerMenuInputControlDevice)
    {
        _importerMenuInputControlDevice = importerMenuInputControlDevice;
        _isVisibleState = false;
    }

    public void Dispose()
    {
        _importerMenuInputControlDevice.OnInputDevice -= OnChangeDevice;
    }

    public void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _importerMenuInputControlDevice.OnInputDevice += OnChangeDevice;
    }

    public void SetVisibleState(bool isVisible)
    {
        _isVisibleState = isVisible;
    }

    public void CheckVisibleCursor()
    {
        if (_importerMenuInputControlDevice.CurrentDevice == DeviceType.KeyboardMouse)
        {
            Debug.Log("CheckVisibleCursor, Переключение на клавиатуру/мышь");
            ControlVisible(CursorLockMode.None);
            return;
        }
        //}
        Debug.Log("CheckVisibleCursor, Переключение на геймпад");
        ControlVisible(CursorLockMode.Locked);
    }


    private void OnChangeDevice(DeviceType deviceType)
    {
        CheckVisibleCursor();
    }

    private void ControlVisible(CursorLockMode cursorLock)
    {
        Cursor.lockState = _isVisibleState ? cursorLock : CursorLockMode.Locked;
    }
}
