using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControlKeyboardInitialization
{
    private GamePadKeyboard _gamePadKeyboard;
    private DataGamePadKeyboardLanguage _dataGamePadKeyboardLanguage;
    private Color _primaryTextColor;
    private Color _secondaryTextColor;

    private int _languageIndex;

    public ControlKeyboardInitialization(GamePadKeyboard gamePadKeyboard)
    {
        _gamePadKeyboard = gamePadKeyboard;
        _dataGamePadKeyboardLanguage = gamePadKeyboard.DataGamePadKeyboardLanguage;
        _primaryTextColor = gamePadKeyboard.PrimaryTextColor;
        _secondaryTextColor = gamePadKeyboard.SecondaryTextColor;
    }

    public void Initialization(GamePadKey gamePadKey)
    {
        CreateSecondaryKeyText(gamePadKey);
        SetInitialization(gamePadKey);
        UpdateText(gamePadKey);
    }

    public void ChangeLanguage(Language language, List<GamePadKey> gamePadKeys)
    {
        GamePadKey gamePadKey;
        for (int i = 0; i < gamePadKeys.Count; i++)
        {
            gamePadKey = gamePadKeys[i];
            GamePadKeyboardLanguageSettings gamePadKeyboardLanguageSettings = _dataGamePadKeyboardLanguage.GetGamePadKeyboardLanguageSettings(gamePadKey.Id);
            gamePadKeyboardLanguageSettings.GetLanguage(language, out string primaryKeyText, out string secondaryKeyText);
            gamePadKey.SetChar(primaryKeyText, secondaryKeyText);
        }
    }



    private void SetInitialization(GamePadKey gamePadKey)
    {
        gamePadKey.Initialization();
    }

    private void CreateSecondaryKeyText(GamePadKey gamePadKey)
    {
        gamePadKey.SecondaryKeyText = CreateSecondaryText(gamePadKey);
    }

    private TextMeshProUGUI CreateSecondaryText(GamePadKey gamePadKey)
    {
        GameObject secondaryTextObj = new GameObject("SecondaryText", typeof(TextMeshProUGUI));
        secondaryTextObj.transform.SetParent(gamePadKey.transform);
        TextMeshProUGUI textComponent = secondaryTextObj.GetComponent<TextMeshProUGUI>();
        textComponent.alignment = TextAlignmentOptions.Center; // Align secondary text top-left

        // Set the scale, position, width, and height
        secondaryTextObj.transform.localScale = Vector3.one;
        secondaryTextObj.transform.localPosition = new Vector3(5, -5, 0);

        // Set the width and height 
        RectTransform rectTransform = secondaryTextObj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(25, 25);

        return textComponent;
    }

    private void UpdateText(GamePadKey gamePadKey)
    {
        if (gamePadKey.PrimaryKeyText != null)
        {
            gamePadKey.PrimaryKeyText.color = _primaryTextColor;
            gamePadKey.PrimaryKeyText.fontSize = 36;  // Font size for the primary text
            gamePadKey.PrimaryKeyText.alignment = TextAlignmentOptions.Center; // Center align
        }

        if (gamePadKey.SecondaryKeyText != null)
        {
            gamePadKey.SecondaryKeyText.color = _secondaryTextColor;
            gamePadKey.SecondaryKeyText.fontSize = 24;  // Font size for the secondary text
            gamePadKey.SecondaryKeyText.alignment = TextAlignmentOptions.TopLeft; // Align top-left

            // Position the secondary key text
            RectTransform rectTransform = gamePadKey.SecondaryKeyText.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0, 1); // Anchor at top-left
            rectTransform.anchorMax = new Vector2(0, 1); // Anchor at top-left
            rectTransform.pivot = new Vector2(0, 1);     // Pivot at top-left
            rectTransform.anchoredPosition = new Vector2(10, -5); // Offset position
            rectTransform.sizeDelta = new Vector2(0, 0); // No extra size
        }
    }
}
