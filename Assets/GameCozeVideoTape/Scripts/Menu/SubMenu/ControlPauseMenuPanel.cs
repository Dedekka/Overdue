using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ControlPauseMenuPanel : IInitializable, IDisposable
{
    private ControlStatePanel _controlStatePanel;
    private GameObject _panelButtonsPause;
    private GameObject _panelSettings;
    private GameObject _panelTutorial;
    private Button _buttonTutorialBack;
    private Button _buttonSettingsBack;
    private Button _buttonSettings;
    private Button _buttonTutorial;

    //public ControlPauseMenuPanel(Button buttonSettings, Button buttonTutorial, ControlStatePanel controlStatePanel, GameObject panelSettings, GameObject panelTutorial)
    public ControlPauseMenuPanel(PanelsPauseMenu PanelsPauseMenu, ControlStatePanel controlStatePanel)
    {
        _buttonSettings = PanelsPauseMenu.ButtonSettings;
        _buttonTutorial = PanelsPauseMenu.ButtonTutorial;
        _controlStatePanel = controlStatePanel;
        _panelSettings = PanelsPauseMenu.PanelSettings;
        _panelTutorial = PanelsPauseMenu.PanelTutorial;
        _buttonTutorialBack = PanelsPauseMenu.ButtonTutorialBack;
        _buttonSettingsBack = PanelsPauseMenu.ButtonSettingsBack;
        _panelButtonsPause = PanelsPauseMenu.PanelButtonsPause;
    }

    public void Initialize()
    {
        _buttonSettings.onClick.AddListener(() => ChangePanel(_panelSettings, _buttonSettings, StatePanelUi.Settings));
        _buttonTutorial.onClick.AddListener(() => ChangePanel(_panelTutorial, _buttonTutorial, StatePanelUi.Tutorial));
        _buttonTutorialBack.onClick.AddListener(() => Back());
        _buttonSettingsBack.onClick.AddListener(() => Back());
    }

    public void Dispose()
    {
        _buttonSettings.onClick.RemoveAllListeners();
        _buttonTutorial.onClick.RemoveAllListeners();
    }

    private void ChangePanel(GameObject currentActivePanel, Button currentActiveButton, StatePanelUi state)
    {
        _panelButtonsPause.SetActive(false);
        _panelSettings.SetActive(false);
        _panelTutorial.SetActive(false);

        _buttonSettings.interactable = true;
        _buttonTutorial.interactable = true;

        currentActivePanel.SetActive(true);
        currentActiveButton.interactable = false;
        _controlStatePanel.ChangeState(state);
    }

    private void Back()
    {
        _panelButtonsPause.SetActive(true);
        _panelSettings.SetActive(false);
        _panelTutorial.SetActive(false);
        _controlStatePanel.ChangeState(StatePanelUi.Pause);
        _buttonSettings.interactable = true;
        _buttonTutorial.interactable = true;
    }

}

public class PanelsPauseMenu
{

    public Button ButtonTutorialBack;
    public Button ButtonSettingsBack;
    public Button ButtonSettings;
    public Button ButtonTutorial;
    public GameObject PanelButtonsPause;
    public GameObject PanelSettings;
    public GameObject PanelTutorial;

    public PanelsPauseMenu
        (
         Button buttonTutorialBack,
          Button buttonSettingsBack,
           Button buttonSettings,
          Button buttonTutorial,
          GameObject panelButtonsPause,
           GameObject panelSettings,
            GameObject panelTutorial
        )
    {
        ButtonTutorialBack = buttonTutorialBack;
        ButtonSettingsBack = buttonSettingsBack;
        ButtonSettings = buttonSettings;
        ButtonTutorial = buttonTutorial;
        PanelButtonsPause = panelButtonsPause;
        PanelSettings = panelSettings;
        PanelTutorial = panelTutorial;
    }

}
