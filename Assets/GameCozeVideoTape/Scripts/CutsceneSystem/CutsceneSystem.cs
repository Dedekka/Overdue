using System;
using Zenject;

public class CutsceneSystem : IDisposable, IInitializable
{
    private CutSceneController _cutSceneController;

    public CutsceneSystem(CutSceneController cutSceneController)
    {
        _cutSceneController = cutSceneController;
    }

    public void Initialize()
    {
        _cutSceneController.Initialization();
        _cutSceneController.StartCutscene(2);
    }

    public void Dispose()
    {
    }
}