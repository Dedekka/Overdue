using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlSubKeyboard
{
    private GamePadKeyboard _gamePadKeyboard;
    private List<GamePadKey> _gamePadKeys;
    private Button _shiftButton;       // Button to toggle Shift mode
    private Button _capsLockButton;    // Button to toggle Caps Lock mode
    private Button _enterButton;       // Button to submit text
    private Button _backspaceButton;   // Button to delete the previous character
    private Button _deleteButton;      // Button to delete the character at caret
    private Button _spaceButton;       // Button to insert a space
    private Button _leftArrowButton;   // Button to move caret left
    private Button _rightArrowButton;  // Button to move caret right
    private Button _upArrowButton;
    private Button _languageButton;
    private TMP_InputField _inputField;

    private bool isCapsLockOn;  // Whether Caps Lock is enabled
    private bool isShiftPressed; // Whether Shift key is pressed
    private bool isEng; // Whether Shift key is pressed

    public ControlSubKeyboard(GamePadKeyboard gamePadKeyboard)
    {
        _gamePadKeyboard = gamePadKeyboard;
        _gamePadKeys = gamePadKeyboard.GamePadKeys;
        _shiftButton = gamePadKeyboard.ShiftButton;
        _capsLockButton = gamePadKeyboard.CapsLockButton;
        _enterButton = gamePadKeyboard.EnterButton;
        _backspaceButton = gamePadKeyboard.BackspaceButton;
        _deleteButton = gamePadKeyboard.DeleteButton;
        _spaceButton = gamePadKeyboard.SpaceButton;
        _leftArrowButton = gamePadKeyboard.LeftArrowButton;
        _rightArrowButton = gamePadKeyboard.RightArrowButton;
        _upArrowButton = gamePadKeyboard.UpArrowButton;
        _languageButton = gamePadKeyboard.LanguageButton;
        isEng = true;
    }

    public void SubSpecialButton()
    {
        _capsLockButton?.onClick.AddListener(ToggleCapsLock);
        _languageButton?.onClick.AddListener(ChangeLanguage);
        _shiftButton?.onClick.AddListener(ToggleShift);
        _spaceButton?.onClick.AddListener(InsertSpaceCharacter);
        _enterButton?.onClick.AddListener(SubmitText);
        _backspaceButton?.onClick.AddListener(DeleteCharacter);
        _deleteButton?.onClick.AddListener(DeleteCharacterAtCaret);
        _leftArrowButton?.onClick.AddListener(MoveCaretLeft);
        _rightArrowButton?.onClick.AddListener(MoveCaretRight);
    }

    public void UnSubSpecialButton()
    {
        _capsLockButton?.onClick.RemoveAllListeners();
        _languageButton?.onClick.RemoveAllListeners();
        _shiftButton?.onClick.RemoveAllListeners();
        _spaceButton?.onClick.RemoveAllListeners();
    }

    public void ResetKeyState()
    {
        isCapsLockOn = false;
        isShiftPressed = false;
        UpdateKeyLabels();
    }

    public void OnKeyPress(GamePadKey gamePadKey)
    {
        string keyText = GetKeyText(gamePadKey);
        InsertCharacter(keyText);

        if (isShiftPressed) ToggleShift();
    }

    private string GetKeyText(GamePadKey gamePadKey)
    {
        // This method determines the correct key text based on Shift and Caps Lock states.
        if (isShiftPressed)
        {
            // If Shift is pressed, use secondary value for special characters or swap letter case
            if (string.IsNullOrEmpty(gamePadKey.SecondaryKey))
            {
                return gamePadKey.PrimaryKey.Length == 1 && char.IsLetter(gamePadKey.PrimaryKey[0])
                    ? (isCapsLockOn ? gamePadKey.PrimaryKey.ToLower() : gamePadKey.PrimaryKey.ToUpper())
                    : gamePadKey.PrimaryKey;  // If it's not a letter, use the primary value (unchanged for Shift)
            }

            return gamePadKey.SecondaryKey;  // Use secondary for non-letters when Shift is on
        }
        else
        {
            // If Shift is not pressed, use the correct text based on Caps Lock
            return isCapsLockOn
                ? gamePadKey.PrimaryKey.ToUpper()  // Caps Lock ON means uppercase letters
                : gamePadKey.PrimaryKey.ToLower(); // Caps Lock OFF means lowercase letters
        }
    }

    private void SubmitText()
    {
        // Submit the text when the "Enter" key or the designated submit button is pressed
        // You can extend this to handle custom submit logic if needed (e.g., send data, close keyboard)
        if (CheckInputField()) return;
        if (_inputField.TryGetComponent(out GamePadInputField input))
        {
            input.Deselected();
        }
    }

    private void MoveCaretLeft() => MoveCaret(-1);

    private void MoveCaretRight() => MoveCaret(1);

    private void MoveCaret(int direction)
    {
        if (CheckInputField()) return;
        int position = _inputField.selectionStringAnchorPosition != _inputField.selectionStringFocusPosition
            ? Mathf.Min(_inputField.selectionStringAnchorPosition, _inputField.selectionStringFocusPosition)
            : Mathf.Clamp(_inputField.caretPosition + direction, 0, _inputField.text.Length);

        _inputField.caretPosition = position;
    }

    private void DeleteCharacterAtCaret()
    {
        if (CheckInputField()) return;
        int start = Mathf.Min(_inputField.selectionStringAnchorPosition, _inputField.selectionStringFocusPosition);
        int end = Mathf.Max(_inputField.selectionStringAnchorPosition, _inputField.selectionStringFocusPosition);

        if (start != end)
        {
            _inputField.text = _inputField.text.Remove(start, end - start);
            _inputField.caretPosition = start;
        }
        else if (_inputField.caretPosition < _inputField.text.Length)
        {
            _inputField.text = _inputField.text.Remove(_inputField.caretPosition, 1);
        }
    }

    private void InsertSpaceCharacter() => InsertCharacter(" ");

    private void DeleteCharacter()
    {
        if (CheckInputField()) return;
        int start = Mathf.Min(_inputField.selectionStringAnchorPosition, _inputField.selectionStringFocusPosition);
        int end = Mathf.Max(_inputField.selectionStringAnchorPosition, _inputField.selectionStringFocusPosition);

        if (start != end)
        {
            // If there's selected text, delete it
            _inputField.text = _inputField.text.Remove(start, end - start);
            _inputField.caretPosition = start;
        }
        else if (_inputField.caretPosition > 0)
        {
            // If no text is selected, delete the character to the left of the caret
            int caretPos = _inputField.caretPosition;
            _inputField.text = _inputField.text.Remove(caretPos - 1, 1);
            _inputField.caretPosition = caretPos - 1;
        }
    }

    private void InsertCharacter(string character)
    {
        if (string.IsNullOrEmpty(character)) return;
        if (CheckInputField()) return;

        int start = Mathf.Min(_inputField.selectionStringAnchorPosition, _inputField.selectionStringFocusPosition);
        int end = Mathf.Max(_inputField.selectionStringAnchorPosition, _inputField.selectionStringFocusPosition);

        if (start != end)
        {
            // If there's selected text, replace it with the new character
            _inputField.text = _inputField.text.Remove(start, end - start).Insert(start, character);
            _inputField.caretPosition = start + character.Length;
            Debug.Log("caret position: " + _inputField.caretPosition);
        }
        else
        {
            // If no text is selected, insert the character at the caret position
            _inputField.text = _inputField.text.Insert(_inputField.caretPosition, character);
            _inputField.caretPosition += character.Length;
            Debug.Log("caret position: " + _inputField.caretPosition);
        }
    }


    private void ChangeLanguage()
    {
        Language language;
        isEng = !isEng;
        if (isEng)
        {
            language = Language.en;
        }
        else
        {
            language = Language.ru;
        }
        _gamePadKeyboard.ChangeLanguage(language);
        //isShiftPressed = false;
        //isCapsLockOn = false;
        UpdateKeyLabels();
    }

    private void ToggleCapsLock()
    {
        isShiftPressed = false;
        isCapsLockOn = !isCapsLockOn;
        UpdateKeyLabels();
    }

    private void ToggleShift()
    {
        isShiftPressed = !isShiftPressed;
        UpdateKeyLabels();
    }

    private void UpdateKeyLabels()
    {
        // Iterate through each key and update the labels based on Caps Lock and Shift states
        foreach (var key in _gamePadKeys)
        {
            if (key.PrimaryKeyText == null || key.SecondaryKeyText == null) /*|| ignoreKeyNames.Contains(key.primaryValue))*/
                continue;

            if (isShiftPressed)
            {
                UpdateKeyTextForShift(key);

            }
            else
            {
                UpdateKeyTextForNormal(key);
            }
        }
    }

    private void UpdateKeyTextForShift(GamePadKey key)
    {
        if (string.IsNullOrEmpty(key.SecondaryKey))
        {
            key.PrimaryKeyText.text = key.PrimaryKey.Length == 1 && char.IsLetter(key.PrimaryKey[0])
                ? (isCapsLockOn ? key.PrimaryKey.ToLower() : key.PrimaryKey.ToUpper())
                : key.PrimaryKey;
        }
        else
        {
            SwapKeyTexts(key);
        }
    }

    private void UpdateKeyTextForNormal(GamePadKey key)
    {
        if (isCapsLockOn)
        {
            if (key.PrimaryKey.Length == 1 && char.IsLetter(key.PrimaryKey[0]))
                key.PrimaryKeyText.text = key.PrimaryKey.ToUpper();
            else
                key.PrimaryKeyText.text = key.PrimaryKey;
        }
        else
        {
            key.PrimaryKeyText.text = key.PrimaryKey.Length == 1 && char.IsLetter(key.PrimaryKey[0])
                ? key.PrimaryKey.ToLower()
                : key.PrimaryKey;
        }
        key.SecondaryKeyText.text = key.SecondaryKey;
    }

    private void SwapKeyTexts(GamePadKey key)
    {
        var temp = key.PrimaryKeyText.text;
        key.PrimaryKeyText.text = key.SecondaryKey;
        key.SecondaryKeyText.text = temp;
    }

    private bool CheckInputField()
    {
        if (_inputField != _gamePadKeyboard.InputField)
        {
            _inputField = _gamePadKeyboard.InputField;
        }
        return _inputField == null;
    }
}
