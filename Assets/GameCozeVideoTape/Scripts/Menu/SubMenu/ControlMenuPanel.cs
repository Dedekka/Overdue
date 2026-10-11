using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControlMenuPanel : IInitializable, IDisposable
{
    private Button _backButton;
    private Button _buttonSettings;
    private Button _buttonTutorial;

    [Header("Panel")]
    private GameObject _mainMenu;
    private GameObject _panelSettings;
    private GameObject _panelTutorial;

    public ControlMenuPanel(DataMenuPanel dataMenuPanel )
    {
        _backButton = dataMenuPanel.BackButton;
        _buttonSettings = dataMenuPanel.ButtonSettings;
        _buttonTutorial = dataMenuPanel.ButtonTutorial;
        _mainMenu = dataMenuPanel.MainMenu;
        _panelSettings = dataMenuPanel.PanelSettings;
        _panelTutorial = dataMenuPanel.PanelTutorial;
    }

    public void Initialize()
    {
        _buttonSettings.onClick.AddListener(() => ControlStatePanel(_panelSettings));
        _buttonTutorial.onClick.AddListener(() => ControlStatePanel(_panelTutorial));
        _backButton.onClick.AddListener(() => Back());
    }

    public void Dispose()
    {
        _buttonSettings.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();
        _buttonTutorial.onClick.RemoveAllListeners();
    }

    private void ControlStatePanel(GameObject currentPanel)
    {
        _mainMenu.gameObject.SetActive(false);
        currentPanel.gameObject.SetActive(true);
        _backButton.gameObject.SetActive(true);
    }

    private void Back()
    {
        _mainMenu.gameObject.SetActive(true);
        _panelSettings.gameObject.SetActive(false);
        _panelTutorial.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }
}