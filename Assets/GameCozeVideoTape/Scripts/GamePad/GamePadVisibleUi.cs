using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class GamePadVisibleUi
{
    private bool _visible;
    private List<GamepadButtonData> _gamepadButtonDatas;

    public GamePadVisibleUi(List<GamepadButtonData> gamepadButtonDatas)
    {
        _gamepadButtonDatas = gamepadButtonDatas;
    }

    public void ControlVisibleGamePadUi(bool isVisible)
    {
        if (_visible == isVisible) { return; }
        _visible = isVisible;
        ChangeVisible(isVisible);
    }

    private void ChangeVisible(bool isVisible)
    {
        GamepadButtonData tempGamepadButtonData;
        for (int i = 0; i < _gamepadButtonDatas.Count; i++)
        {
            tempGamepadButtonData = _gamepadButtonDatas[i];
            if (tempGamepadButtonData.ImageButton == null) { continue; }

            for (int j = 0; j < tempGamepadButtonData.ImageButton.Count; j++)
            {
                tempGamepadButtonData.ImageButton[j].gameObject.SetActive(isVisible);
            }
        }
    }
}

public enum GamepadButton
{
    L1,
    L2,
    R1,
    R2,
    O,
    Trl,
    Rs,
    Share,
    X
}

[Serializable]
public class GamepadButtonData
{
    public List<Image> ImageButton;
    public GamepadButton gamepadButton;
}