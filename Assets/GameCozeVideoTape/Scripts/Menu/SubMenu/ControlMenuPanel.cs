using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControlMenuPanel : IInitializable, IDisposable
{
    private Button _buttonSettings;
    private Button _backButton;

    [Header("Panel")]
    private GameObject _mainMenu;
    private GameObject _panelSettings;

    public ControlMenuPanel(Button buttonSettings, Button backButton, GameObject mainMenu, GameObject panelSettings )
    {
        _buttonSettings = buttonSettings;
        _backButton = backButton;
        _mainMenu = mainMenu;
        _panelSettings = panelSettings;
    }

    public void Initialize()
    {
        _buttonSettings.onClick.AddListener(() => _mainMenu.gameObject.SetActive(false));
        _buttonSettings.onClick.AddListener(() => _panelSettings.gameObject.SetActive(true));
        _backButton.onClick.AddListener(() => _mainMenu.gameObject.SetActive(true));
    }

    public void Dispose()
    {
        _buttonSettings.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();
    }
}