using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static UnityEngine.InputManagerEntry;

public class TutorialInstaller : MonoInstaller
{
    [Header("TutorialEvent")]
    [SerializeField] private QuestViewUi _questViewUi;

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
        FindSub();
        BindTutorialSystem();
        BindTutorialControl();
        BindListener();
        BindImporter();
    }

  

    private void FindSub()
    {
        
        Container.Bind<DataTutorialEvent>()
           .FromResource(PathConst.DataTutorialEventAsset)
           .AsSingle();

        Container.Bind<DataTutorialEventLanguage>()
           .FromResource(PathConst.DataTutorialEventLanguageAsset)
           .AsSingle();
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


        Container.Bind<QuestViewUi>()
          .FromInstance(_questViewUi)
          .AsSingle();

        Container.Bind<ControlComplited>()
          .AsSingle();

        Container.Bind<FactoryComplitedHistoryEvent>()
          .AsSingle();


    }

    private void BindTutorialSystem()
    {
        Container.BindInterfacesAndSelfTo<GoalController>()
       .AsSingle();

        Container.Bind<GoalContext>()
       .AsSingle();

        Container.Bind<GoalFactory>()
       .AsSingle();

        Container.Bind<ControlGoalLanguage>()
       .AsSingle();
    }

    private void BindListener()
    {
        Container.Bind<ListenerInputMove>()
    .AsSingle();

        Container.Bind<ListenerInventory>()
       .AsSingle();

        Container.Bind<ListenerPlayerUi>()
       .AsSingle();

        Container.Bind<ListenerTv>()
       .AsSingle();

        Container.Bind<ListenerAudioRecorder>()
       .AsSingle();

        Container.Bind<ListenerPhone>()
       .AsSingle();

        Container.Bind<ListenerPresentSystem>()
       .AsSingle();
    }

    private void BindImporter()
    {
        
    }
}