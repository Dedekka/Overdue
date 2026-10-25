using System;
using UnityEngine;
using Zenject;

public class QuestInstaller : MonoInstaller
{

    [Header("TutorialEvent")]
    [SerializeField] private QuestViewUi _questViewUi;

    public override void InstallBindings()
    {
        FindSub();
        BindTutorialControl();
        BindTutorialSystem();
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
        //Container.BindInterfacesAndSelfTo<TutorialControlPanelSettings>()
        //   .AsSingle();

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

        Container.Bind<ListenerContext>()
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
        Container.BindInterfacesAndSelfTo<ImporterDeviceControlGoalTextIcon>()
         .AsSingle();
    }
}