using UnityEngine;
using Zenject;

public class DialogueInstaller : MonoInstaller
{
    [SerializeField] private ViewDialog _viewDialog;
    [SerializeField] private float _timeWaitChar;
    [SerializeField] private float _timeWaitLine;
    private DataDialogue _dataDialogue;

    public override void InstallBindings()
    {
        FindSub();
        BindDialogue();
        BindImporter();
    }

    private void FindSub()
    {
        _dataDialogue = Resources.Load<DataDialogue>(PathConst.DataDialogueAsset);
    }

    private void BindDialogue()
    {
        Container.Bind<DialogTest>()
            .AsSingle();

        Container.Bind<DialogSound>()
            .AsSingle();

        Container.Bind<DialogEvent>()
            .AsSingle();

        Container.Bind<DialogSystem>()
            .AsSingle()
            .WithArguments(_dataDialogue, _timeWaitLine);

        Container.Bind<DialogWaiter>()
            .AsSingle()
            .WithArguments(_timeWaitChar);

        Container.Bind<ViewDialog>()
            .FromInstance(_viewDialog)
            .AsSingle();
    }

    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterDialogWaiterViewDialog>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<ImporterDialogSystemViewDialog>()
            .AsSingle();

        Container.BindInterfacesAndSelfTo<AudioDialogSoundImporter>()
            .AsSingle();
    }
}