using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TutorialInstaller : MonoInstaller
{
    [Header("TutorialButtonUi")]
    [SerializeField] private Button _buttonTutorialSorting;
    [SerializeField] private Button _buttonTutorialVCR;
    [SerializeField] private Button _buttonTutorialPhone;
    [SerializeField] private Button _buttonTutorialDecorating;
    [SerializeField] private Button _buttonTutorialMusic;
    [SerializeField] private Button _buttonTutorialSunset;

    [Header("PanelTutorialUi")]

    [SerializeField] private GameObject _sortingPanel;
    [SerializeField] private GameObject _vCRPanel;
    [SerializeField] private GameObject _phonePanel;
    [SerializeField] private GameObject _decoratingPanel;
    [SerializeField] private GameObject _musicPanel;
    [SerializeField] private GameObject _sunsetPanel;

    public override void InstallBindings()
    {
        BindTutorialControl();
    }

    private void BindTutorialControl()
    {
        Container.Bind<ButtonsTutorial>()
           .AsSingle()
           .WithArguments
           (
            _buttonTutorialSorting,
            _buttonTutorialVCR,
            _buttonTutorialPhone,
            _buttonTutorialDecorating,
            _buttonTutorialMusic,
            _buttonTutorialSunset
            );

        Container.Bind<PanelsTutorial>()
           .AsSingle()
           .WithArguments
           (
            _sortingPanel,
            _vCRPanel,
            _phonePanel,
            _decoratingPanel,
            _musicPanel,
            _sunsetPanel
            );


        Container.BindInterfacesAndSelfTo<TutorialControlPanelSettings>()
           .AsSingle();
    }
}