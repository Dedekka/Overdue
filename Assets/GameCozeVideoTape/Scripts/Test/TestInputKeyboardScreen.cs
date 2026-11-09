using Steamworks;
using TMPro;
using UnityEngine;

public class TestInputKeyboardScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField TMP_InputField;
    [SerializeField] private Vector4 _pos;

    private void Awake()
    {
        TMP_InputField.onSelect.AddListener((x) => ShowGamepadTextInput());
    }

    private void ShowGamepadTextInput()
    {
        //if (SteamUtils.ShowGamepadTextInput(EGamepadTextInputMode.k_EGamepadTextInputModeNormal, EGamepadTextInputLineMode.k_EGamepadTextInputLineModeMultipleLines, "Мой текст", 12, "Другой текст"))
        //{
        //    Debug.Log("ShowGamepadTextInput = True");
        //    return;
        //}
        //else { 
        //Debug.Log("ShowGamepadTextInput = False");

        //}
        int nTextFieldXPosition = (int)_pos.x;
        int nTextFieldYPosition = (int)_pos.y;
        int nTextFieldWidth = (int)_pos.z;
        int nTextFieldHeight = (int)_pos.w;

        if (SteamUtils.ShowFloatingGamepadTextInput(EFloatingGamepadTextInputMode.k_EFloatingGamepadTextInputModeModeMultipleLines,
            nTextFieldXPosition, nTextFieldYPosition, nTextFieldWidth, nTextFieldHeight))
        {
            Debug.Log("ShowGamepadTextInput = true");
        }
        else
        {
            Debug.Log("ShowGamepadTextInput = False");
        }
    }
}