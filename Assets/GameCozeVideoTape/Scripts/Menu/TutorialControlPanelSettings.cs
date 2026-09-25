using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TutorialControlPanelSettings : IDisposable, IInitializable
{
    private ButtonsTutorial _buttonsTutorial;
    private PanelsTutorial _panelsTutorial;
    private List<Button> _buttonsList;
    private List<GameObject> _panelsList;

    public TutorialControlPanelSettings(ButtonsTutorial buttonsTutorial, PanelsTutorial panelsTutorial)
    {
        _buttonsTutorial = buttonsTutorial;
        _panelsTutorial = panelsTutorial;
    }

    public void Initialize()
    {
        _buttonsList = _buttonsTutorial.GetButtons();
        _panelsList = _panelsTutorial.GetPanels();
        ControlStatePanel(0);
        _buttonsTutorial.ButtonTutorialSorting.onClick.AddListener(() => { ControlStatePanel(0); });
        _buttonsTutorial.ButtonTutorialVCR.onClick.AddListener(() => { ControlStatePanel(1); });
        _buttonsTutorial.ButtonTutorialPhone.onClick.AddListener(() => { ControlStatePanel(2); });
        _buttonsTutorial.ButtonTutorialReturns.onClick.AddListener(() => { ControlStatePanel(3); });
        _buttonsTutorial.ButtonTutorialDecorating.onClick.AddListener(() => { ControlStatePanel(4); });
        _buttonsTutorial.ButtonTutorialMusic.onClick.AddListener(() => { ControlStatePanel(5); });
    }

    public void Dispose()
    {
        _buttonsTutorial.ButtonTutorialSorting.onClick.RemoveAllListeners();
        _buttonsTutorial.ButtonTutorialVCR.onClick.RemoveAllListeners();
        _buttonsTutorial.ButtonTutorialPhone.onClick.RemoveAllListeners();
        _buttonsTutorial.ButtonTutorialReturns.onClick.RemoveAllListeners();
        _buttonsTutorial.ButtonTutorialDecorating.onClick.RemoveAllListeners();
        _buttonsTutorial.ButtonTutorialMusic.onClick.RemoveAllListeners();
    }

    private void ControlStatePanel(int index)
    {
        int count = _buttonsList.Count;
        if (index >= count)
        {
            Debug.LogError($"Index >= count Tutorial UI, Index:{index}, Count:{count}");
            return;
        }
        if (_buttonsList.Count != _panelsList.Count)
        {
            Debug.LogError($"Not found Full Ui, ButtonsList.Count:{_buttonsList.Count},PanelsList.Count{_panelsList.Count}");
            return;
        }

        for (int i = 0; i < count; i++)
        {
            _buttonsList[i].interactable = true;
            _panelsList[i].SetActive(false);
        }
        _buttonsList[index].interactable = false;
        _panelsList[index].SetActive(true);
    }

    // Все кнопки вкл как активные
    // Когда эта кнопка нажата она становится не активной\

    // Выключаются все панели отображения Ui
    // Вкл Ui панель соответствующая кнопке 


}

public class ButtonsTutorial
{
    public Button ButtonTutorialSorting;
    public Button ButtonTutorialVCR;
    public Button ButtonTutorialPhone;
    public Button ButtonTutorialReturns;
    public Button ButtonTutorialDecorating;
    public Button ButtonTutorialMusic;

    public ButtonsTutorial(Button buttonTutorialSorting, Button buttonTutorialVCR, Button buttonTutorialPhone, Button buttonTutorialReturns, Button buttonTutorialDecorating, Button buttonTutorialMusic)
    {
        ButtonTutorialSorting = buttonTutorialSorting;
        ButtonTutorialVCR = buttonTutorialVCR;
        ButtonTutorialPhone = buttonTutorialPhone;
        ButtonTutorialReturns = buttonTutorialReturns;
        ButtonTutorialDecorating = buttonTutorialDecorating;
        ButtonTutorialMusic = buttonTutorialMusic;
    }

    public List<Button> GetButtons()
    {
        List<Button> buttons = new List<Button>()
        {

            ButtonTutorialSorting,
            ButtonTutorialVCR,
            ButtonTutorialPhone,
            ButtonTutorialReturns,
            ButtonTutorialDecorating,
            ButtonTutorialMusic
        };
        return buttons;
    }
}

public class PanelsTutorial
{
    public GameObject SortingPanel;
    public GameObject VCRPanel;
    public GameObject PhonePanel;
    public GameObject ReturnsPanel;
    public GameObject DecoratingPanel;
    public GameObject MusicPanel;

    public PanelsTutorial(GameObject sortingPanel, GameObject vCRPanel, GameObject phonePanel, GameObject returnsPanel, GameObject decoratingPanel, GameObject musicPanel)
    {
        SortingPanel = sortingPanel;
        VCRPanel = vCRPanel;
        PhonePanel = phonePanel;
        ReturnsPanel = returnsPanel;
        DecoratingPanel = decoratingPanel;
        MusicPanel = musicPanel;
    }

    public List<GameObject> GetPanels()
    {
        List<GameObject> buttons = new List<GameObject>()
        {

            SortingPanel,
            VCRPanel,
            PhonePanel,
            ReturnsPanel,
            DecoratingPanel,
            MusicPanel
        };
        return buttons;
    }
}
