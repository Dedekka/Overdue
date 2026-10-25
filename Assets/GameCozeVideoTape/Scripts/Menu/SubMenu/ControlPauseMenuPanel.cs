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
    private Button _buttonBack;
    private Button _buttonSettings;
    private Button _buttonTutorial;
    private GamePadMenu _gamePadMenu;
    private GamePadSelecter _gamePadSelecter;

    public ControlPauseMenuPanel(PanelsPauseMenu PanelsPauseMenu, ControlStatePanel controlStatePanel, GamePadMenu gamePadMenu, GamePadSelecter gamePadSelecter)
    {
        _buttonSettings = PanelsPauseMenu.ButtonSettings;
        _buttonTutorial = PanelsPauseMenu.ButtonTutorial;
        _controlStatePanel = controlStatePanel;
        _panelSettings = PanelsPauseMenu.PanelSettings;
        _panelTutorial = PanelsPauseMenu.PanelTutorial;
        _buttonBack = PanelsPauseMenu.ButtonSettingsBack;
        _panelButtonsPause = PanelsPauseMenu.PanelButtonsPause;
        _gamePadMenu = gamePadMenu;
        _gamePadSelecter = gamePadSelecter;
    }

    public void Initialize()
    {
        _buttonSettings.onClick.AddListener(() => ChangePanel(_panelSettings, StatePanelUi.Settings));
        _buttonTutorial.onClick.AddListener(() => ChangePanel(_panelTutorial, StatePanelUi.Tutorial));
        _buttonBack.onClick.AddListener(() => Back());
    }

    public void Dispose()
    {
        _buttonSettings.onClick.RemoveAllListeners();
        _buttonTutorial.onClick.RemoveAllListeners();
    }

    public void OnEnable()
    {
        _panelButtonsPause.SetActive(true);
        _gamePadMenu.ActiveButton(0);
    }

    public void OnDisable()
    {
        _buttonBack.gameObject.SetActive(false);
        _panelSettings.SetActive(false);
        _panelTutorial.SetActive(false);
        Back();
    }


    private void ChangePanel(GameObject currentActivePanel, StatePanelUi state)
    {
        _gamePadSelecter.ControlStatePanel((int)state);
        _panelButtonsPause.SetActive(false);
        _buttonBack.gameObject.SetActive(true);
        //_panelSettings.SetActive(false);
        //_panelTutorial.SetActive(false);
        currentActivePanel.SetActive(true);

        //_buttonSettings.interactable = true;
        //_buttonTutorial.interactable = true;

        //currentActiveButton.interactable = false;

        _gamePadMenu.ActiveButton((int)state);
        _controlStatePanel.ChangeState(state);
    }

    public void Back()
    {
        _gamePadSelecter.ControlStatePanel(0);
        _gamePadMenu.ActiveButton(0);
        _buttonBack.gameObject.SetActive(false);
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
    public Button ButtonSettingsBack;
    public Button ButtonSettings;
    public Button ButtonTutorial;
    public GameObject PanelButtonsPause;
    public GameObject PanelSettings;
    public GameObject PanelTutorial;

    public PanelsPauseMenu
        (
          Button buttonSettingsBack,
           Button buttonSettings,
          Button buttonTutorial,
          GameObject panelButtonsPause,
           GameObject panelSettings,
            GameObject panelTutorial
        )
    {
        ButtonSettingsBack = buttonSettingsBack;
        ButtonSettings = buttonSettings;
        ButtonTutorial = buttonTutorial;
        PanelButtonsPause = panelButtonsPause;
        PanelSettings = panelSettings;
        PanelTutorial = panelTutorial;
    }

}
