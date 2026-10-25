using System.Collections.Generic;
using UnityEngine.UI;

public class ControlGamePadVisible
{
    private GamePadUiSettings _gamePadUiSettings;
    private List<GamepadButtonData> _gamepadButtonDatas;
    private DeviceType _tempDeviceType;

    public ControlGamePadVisible(GamePadUiSettings gamePadUiSettings, List<GamepadButtonData> gamepadButtonDatas)
    {
        _gamePadUiSettings = gamePadUiSettings;
        _gamepadButtonDatas = gamepadButtonDatas;
    }

    public void OnChangeDevice(DeviceType deviceType)
    {
        if (_tempDeviceType == deviceType) { return; }
        _tempDeviceType = deviceType;
        ChangeUi();
    }

    private void ChangeUi()
    {
        GamepadButtonData gamepadButtonData;
        List<Image> ImageButton;
        for (int i = 0; i < _gamepadButtonDatas.Count; i++)
        {
            gamepadButtonData = _gamepadButtonDatas[i];
            ImageButton = gamepadButtonData.ImageButton;
            for (int j = 0; j < ImageButton.Count; j++)
            {
                ImageButton[j].sprite = _gamePadUiSettings.GetIcon(gamepadButtonData.gamepadButton, _tempDeviceType);
            }
        }
    }
}