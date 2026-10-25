using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [Header("Buttons")]
    [SerializeField] private Button _buttonNewGame;
    [SerializeField] private Button _buttonExit;
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private Button _buttonFeedbackMenu;
    [SerializeField] private Button _buttonTutorial;
    [SerializeField] private Button _backButton;

    [Header("Panel")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _panelSettings;
    [SerializeField] private GameObject _panelTutorial;


    public override void InstallBindings()
    {
        BindSub();
        BindControl();
    }



    private void BindSub()
    {
        Container.BindInterfacesAndSelfTo<ImporterButtonMenuControlLogic>()
          .AsSingle()
          .WithArguments(_buttonNewGame, _buttonExit, _buttonFeedbackMenu);
    }

    private void BindControl()
    {
        Container.BindInterfacesAndSelfTo<ControlMenuPanel>()
          .AsSingle()
          .WithArguments(
            new DataMenuPanel()
            {
                BackButton = _backButton,
                ButtonSettings = _buttonSettings,
                ButtonTutorial = _buttonTutorial,
                MainMenu = _mainMenu,
                PanelSettings = _panelSettings,
                PanelTutorial = _panelTutorial,
            });


        Container.Bind<PlayerSystemActions>()
           .AsSingle();

    }



}

public class DataMenuPanel
{
    [Header("Buttons")]
    public Button BackButton;
    public Button ButtonSettings;
    public Button ButtonTutorial;

    [Header("Panel")]
    public GameObject MainMenu;
    public GameObject PanelSettings;
    public GameObject PanelTutorial;
}
