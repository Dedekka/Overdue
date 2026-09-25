using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TutorialInstaller : MonoInstaller
{
    [Header("TutorialButtonUi")]
    [SerializeField] private Button _buttonTutorialSorting;
    [SerializeField] private Button _buttonTutorialVCR;
    [SerializeField] private Button _buttonTutorialPhone;
    [SerializeField] private Button _buttonTutorialReturns;
    [SerializeField] private Button _buttonTutorialDecorating;
    [SerializeField] private Button _buttonTutorialMusic;
    [Header("PanelTutorialUi")]
    [SerializeField] private GameObject _sortingPanel;
    [SerializeField] private GameObject _vCRPanel;
    [SerializeField] private GameObject _phonePanel;
    [SerializeField] private GameObject _returnsPanel;
    [SerializeField] private GameObject _decoratingPanel;
    [SerializeField] private GameObject _musicPanel;

    public override void InstallBindings()
    {
        BindTutorialSystem();
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
            _buttonTutorialReturns,
            _buttonTutorialDecorating,
            _buttonTutorialMusic
            );

        Container.Bind<PanelsTutorial>()
           .AsSingle()
           .WithArguments
           (
            _sortingPanel,
            _vCRPanel,
            _phonePanel,
            _returnsPanel,
            _decoratingPanel,
            _musicPanel
            );


        Container.BindInterfacesAndSelfTo<TutorialControlPanelSettings>()
           .AsSingle();
    }

    private void BindTutorialSystem()
    {
        Container.BindInterfacesAndSelfTo<TutorialSystem>()
       .AsSingle();

        Container.Bind<ControlInputListener>()
       .AsSingle();
    }
}