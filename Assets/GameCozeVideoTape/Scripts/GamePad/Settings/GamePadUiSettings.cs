using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GamePadUiSettings", menuName = "Create/GamePadUiSettings")]
public class GamePadUiSettings : ScriptableObject
{
    [SerializeField] private List<GamepadDataImage> IconGamepadData;

    [ContextMenu("SetImage")]
    private void SetImage()
    {
        IconGamepadData = new List<GamepadDataImage>();
        IconGamepadData.Add(new GamepadDataImage()
        {
            DeviceType = DeviceType.GamepadXbox,
            GamepadButtonImages = GetList()
        });
        IconGamepadData.Add(new GamepadDataImage()
        {
            DeviceType = DeviceType.GamepadSony,
            GamepadButtonImages = GetList()
        });
    }

    public Sprite GetIcon(GamepadButton gamepadButton, DeviceType deviceType)
    {
        return FindSprite(gamepadButton, deviceType);
    }

    private Sprite FindSprite(GamepadButton gamepadButton, DeviceType deviceType)
    {
        GamepadDataImage gamepadDataImage = null;
        GamepadButtonImage gamepadButtonImage = null;
        if (deviceType == DeviceType.Gamepad|| deviceType == DeviceType.GamepadSony)
        {
            gamepadDataImage = IconGamepadData.Find((x)=>x.DeviceType == DeviceType.GamepadSony);
        }
        else if (deviceType == DeviceType.GamepadXbox)
        {
            gamepadDataImage = IconGamepadData.Find((x) => x.DeviceType == DeviceType.GamepadXbox);
        }

        if (gamepadDataImage == null)
        {
            Debug.LogError($"NOT Found FindSprite, DeviceType:{deviceType}, GamepadButton{gamepadButton}");
            return null;
        }

        gamepadButtonImage = gamepadDataImage.GamepadButtonImages.Find((x) => x.GamepadButton == gamepadButton);

        if (gamepadButtonImage == null)
        {
            Debug.LogError($"NOT Found GamepadButtonImage, DeviceType:{deviceType}, GamepadButton{gamepadButton}");
            return null;
        }

        return gamepadButtonImage.Icon;
    }

    private List<GamepadButtonImage> GetList()
    {
        List<GamepadButtonImage> gamepadButtonImages = new List<GamepadButtonImage>();
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.L1 });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.L2 });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.R1 });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.R2 });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.O });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.Trl });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.Rs });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.Share });
        gamepadButtonImages.Add(new GamepadButtonImage() { GamepadButton = GamepadButton.X });
        return gamepadButtonImages;
    }

}

[Serializable]
public class GamepadDataImage
{
    public DeviceType DeviceType;
    public List<GamepadButtonImage> GamepadButtonImages;
}


[Serializable]
public class GamepadButtonImage
{
    public GamepadButton GamepadButton;
    public Sprite Icon;
}

//[Serializable]
//public class GamepadButtonData
//{
//    public List<Image> ImageButton;
//    public GamepadButton gamepadButton;
//}