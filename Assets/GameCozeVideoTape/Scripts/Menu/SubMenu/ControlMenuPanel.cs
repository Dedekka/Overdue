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
    private GamePadMenu _gamePadMenu;
    private GamePadSelecter _gamePadSelecter;

    public ControlMenuPanel(DataMenuPanel dataMenuPanel, GamePadMenu gamePadMenu, GamePadSelecter gamePadSelecter )
    {
        _backButton = dataMenuPanel.BackButton;
        _buttonSettings = dataMenuPanel.ButtonSettings;
        _buttonTutorial = dataMenuPanel.ButtonTutorial;
        _mainMenu = dataMenuPanel.MainMenu;
        _panelSettings = dataMenuPanel.PanelSettings;
        _panelTutorial = dataMenuPanel.PanelTutorial;
        _gamePadMenu = gamePadMenu;
        _gamePadSelecter = gamePadSelecter;
    }

    public void Initialize()
    {
        _buttonSettings.onClick.AddListener(() => ControlStatePanel(_panelSettings,1));
        _buttonTutorial.onClick.AddListener(() => ControlStatePanel(_panelTutorial,2));
        _backButton.onClick.AddListener(() => Back());
    }

    public void Dispose()
    {
        _buttonSettings.onClick.RemoveAllListeners();
        _backButton.onClick.RemoveAllListeners();
        _buttonTutorial.onClick.RemoveAllListeners();
    }

    private void ControlStatePanel(GameObject currentPanel,int indexPanel)
    {
        _gamePadSelecter.ControlStatePanel(indexPanel);
        _mainMenu.gameObject.SetActive(false);
        currentPanel.gameObject.SetActive(true);
        _backButton.gameObject.SetActive(true);
        _gamePadMenu.ActiveButton(indexPanel);
    }

    private void Back()
    {
        _gamePadSelecter.ControlStatePanel(0);
        _gamePadMenu.ActiveButton(0);
        _mainMenu.gameObject.SetActive(true);
        _panelSettings.gameObject.SetActive(false);
        _panelTutorial.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(false);
    }
}