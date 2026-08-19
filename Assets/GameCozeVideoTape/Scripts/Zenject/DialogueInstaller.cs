using System;
using Unity.Cinemachine;
using UnityEngine;
using Zenject;

public class DialogueInstaller : MonoInstaller
{
    [SerializeField] private ViewDialog _viewDialog;
    [SerializeField] private float _timeWaitChar;
    [SerializeField] private float _timeWaitLine;
    //private DataDialogue _dataDialogue;
    //private DataOpera _dataOpera;

   

    public override void InstallBindings()
    {
        FindSub();
        BindDialogue();
        BindRealizer();
        BindImporter();
        BindTv();

    }

    private void FindSub()
    {
        //_dataDialogue = Resources.Load<DataDialogue>(PathConst.DataDialogueAsset);
        //_dataOpera = Resources.Load<DataOpera>(PathConst.DataOperaAsset);

        Container.Bind<DataOpera>()
            .FromResource(PathConst.DataOperaAsset)
            .AsSingle();

        Container.Bind<DataDialogue>()
            .FromResource(PathConst.DataDialogueAsset)
            .AsSingle();
    }

    private void BindDialogue()
    {
        Container.Bind<DialogCall>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<DialogSubtitles>()
            .AsSingle();

        Container.Bind<DialogSound>()
            .AsSingle();

        Container.Bind<DialogEventManager>()
            .AsSingle();

        Container.Bind<DialogEvent>()
            .AsSingle();


        Container.Bind<DialogSystem>()
            .AsSingle()
            .WithArguments(_timeWaitLine);

        Container.Bind<DialogWaiter>()
            .AsSingle()
            .WithArguments(_timeWaitChar);

        Container.Bind<ViewDialog>()
            .FromInstance(_viewDialog)
            .AsSingle();
    }

    private void BindRealizer()
    {
        Container.Bind<DialogSystemCall>()
            .AsSingle();
            //.WithArguments(_dataDialogue);

        Container.Bind<DialogSystemSubtitles>()
            .AsSingle();
            //.WithArguments(_dataOpera);
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterDialogWaiterViewDialog>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterDialogSystemViewDialog>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<AudioDialogSoundImporter>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterDialogEventManager>()
            .AsSingle();

        //Container.BindInterfacesAndSelfTo<ImporterSystemSubtitlesVideoControl>()
        //    .AsSingle();
    }

    private void BindTv()
    {
        Container.BindInterfacesAndSelfTo<TvManager>()
          .AsSingle();
          //.WithArguments(_dataOpera);

        Container.Bind<SubtitlesWaiter>()
          .AsSingle();
    }
}