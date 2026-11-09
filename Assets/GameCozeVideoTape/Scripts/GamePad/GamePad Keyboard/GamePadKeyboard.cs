using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GamePadKeyboard : MonoBehaviour
{
    #region PublicField
    public List<GamePadKey> GamePadKeys => _gamePadKeys;
    public Button ShiftButton => _shiftButton;       // Button to toggle Shift mode
    public Button CapsLockButton => _capsLockButton;    // Button to toggle Caps Lock mode
    public Button EnterButton => _enterButton;      // Button to submit text
    public Button BackspaceButton => _backspaceButton;   // Button to delete the previous character
    public Button DeleteButton => _deleteButton;      // Button to delete the character at caret
    public Button SpaceButton => _spaceButton;       // Button to insert a space
    public Button LeftArrowButton => _leftArrowButton;   // Button to move caret left
    public Button RightArrowButton => _rightArrowButton;  // Button to move caret right
    public Button UpArrowButton => _upArrowButton;
    public Button LanguageButton => _languageButton;
    public DataGamePadKeyboardLanguage DataGamePadKeyboardLanguage => _dataGamePadKeyboardLanguage;
    public TMP_InputField InputField => _inputField;
    public Color PrimaryTextColor => _primaryTextColor;
    public Color SecondaryTextColor => _secondaryTextColor;


    #endregion

    [Space]
    [Header("Special Keys")]
    [SerializeField] private Button _shiftButton;       // Button to toggle Shift mode
    [SerializeField] private Button _capsLockButton;    // Button to toggle Caps Lock mode
    [SerializeField] private Button _enterButton;       // Button to submit text
    [SerializeField] private Button _backspaceButton;   // Button to delete the previous character
    [SerializeField] private Button _deleteButton;      // Button to delete the character at caret
    [SerializeField] private Button _spaceButton;       // Button to insert a space
    [SerializeField] private Button _leftArrowButton;   // Button to move caret left
    [SerializeField] private Button _rightArrowButton;  // Button to move caret right
    [SerializeField] private Button _upArrowButton;
    [SerializeField] private Button _languageButton;

    private DataGamePadKeyboardLanguage _dataGamePadKeyboardLanguage;

    private TMP_InputField _inputField;
    private ControlKeyboardInitialization _controlKeyboardInitialization;
    private ControlSubKeyboard _controlSubKeyboard;
    private List<GamePadKey> _gamePadKeys;
    private Color _primaryTextColor;
    private Color _secondaryTextColor;

    [Inject]
    public void Construct(DataGamePadKeyboardLanguage dataGamePadKeyboardLanguage, StateColor stateColor)
    {
        _dataGamePadKeyboardLanguage = dataGamePadKeyboardLanguage;
        _primaryTextColor = stateColor.PrimaryTextColor;
        _secondaryTextColor = stateColor.SelectedColor;
    }

    public void OnAwake()
    {
        _gamePadKeys = GetComponentsInChildren<GamePadKey>().ToList();
        _controlKeyboardInitialization = new ControlKeyboardInitialization(this);
        _controlSubKeyboard = new ControlSubKeyboard(this);
    }

    public void OnStart()
    {
        Initialization();
        _controlSubKeyboard.SubSpecialButton();
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        ResetKeyState();
    }

    private void OnDestroy()
    {
        _inputField = null;
        _controlSubKeyboard.UnSubSpecialButton();
        foreach (var gamePadKey in _gamePadKeys)
        {
            gamePadKey.Button.onClick.RemoveAllListeners();
        }
    }

    public void ChangeLanguage(Language language)
    {
        _controlKeyboardInitialization.ChangeLanguage(language, _gamePadKeys);
    }

    public void Setup(TMP_InputField inputField)
    {
        _inputField = inputField;
        ResetKeyState();
    }

    private void ResetKeyState()
    {
        _controlSubKeyboard.ResetKeyState();
    }

    private void Initialization()
    {
        foreach (var gamePadKey in _gamePadKeys)
        {
            _controlKeyboardInitialization.Initialization(gamePadKey);
            gamePadKey.Button.onClick.AddListener(() => OnKeyPress(gamePadKey));
        }

        //for (int i = 0; i < _gamePadKeys.Count; i++)
        //{
        //    gamePadKey = _gamePadKeys[i];

        //    _controlKeyboardInitialization.Initialization(gamePadKey);
        //    gamePadKey.Button.onClick.AddListener(() =>OnKeyPress(gamePadKey));
        //}
        ChangeLanguage(Language.en);
    }

    private void OnKeyPress(GamePadKey gamePadKey)
    {
        _controlSubKeyboard.OnKeyPress(gamePadKey);
    }
}