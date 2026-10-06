using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CutsceneInstaller : MonoInstaller
{
    [SerializeField] private List<CutsceneStruct> _cutscenes = new List<CutsceneStruct>();
    [SerializeField] private CanvasGroup _blackScreen;
    
    public override void InstallBindings()
    {
        BindCutsceneSystem();
    }

    private void BindCutsceneSystem()
    {
        Container.BindInterfacesAndSelfTo<CutsceneSystem>()
            .AsSingle();

        Container.Bind<CutSceneController>()
              .AsSingle();

        Container.BindInterfacesAndSelfTo<ControlStateCutScene>()
              .AsSingle();

        Container.Bind<FactoryCutScene>()
              .AsSingle()
              .WithArguments(_cutscenes);

        Container.Bind<CutsceneBlackScreen>()
              .AsSingle()
              .WithArguments(_blackScreen);
    }
}