using System;
using System.Collections.Generic;
using UnityEngine.Playables;
using Zenject;

public class ControlStateCutScene :IDisposable, IInitializable
{
    private List<StateCutScene> _stateCutScenes;
    private FactoryCutScene _factoryCutScene;
    private CutSceneController _cutSceneController;
    private int _currentCutsceneIndex;
    private StateCutScene _currentStateCutScene;

    public ControlStateCutScene(FactoryCutScene factoryCutScene, CutSceneController cutSceneController)
    {
        _factoryCutScene = factoryCutScene;
        _cutSceneController = cutSceneController;
    }

    public void Initialize()
    {
        _stateCutScenes = _factoryCutScene.GetStateCutScenes();
        _cutSceneController.OnStartCutscene += OnStartCutscene;
        _cutSceneController.OnEndCutscene += OnEndCutscene;
        CheckStartCutScene(_cutSceneController.CurrentCutscene);
    }

    public void Dispose()
    {
        _cutSceneController.OnStartCutscene -= OnStartCutscene;
        _cutSceneController.OnEndCutscene -= OnEndCutscene;
    }

    private void OnStartCutscene(int cutsceneIndex)
    {
        _currentCutsceneIndex = cutsceneIndex;
        ChangeStateCutScene();
    }

    private void OnEndCutscene()
    {
        if (_currentStateCutScene == null) { return; }

        _currentStateCutScene.EndCutscene();
    }

    private void ChangeStateCutScene()
    {
        _currentStateCutScene = _stateCutScenes.Find((x) => x.IDCutscene == _currentCutsceneIndex);

        if (_currentStateCutScene == null ) { return; }

        _currentStateCutScene.StartCutscene();
    }

    private void CheckStartCutScene(PlayableDirector PlayableDirector)
    {
        if (PlayableDirector == null ) { return; }
        if (PlayableDirector.state == PlayState.Playing)
        {
            OnStartCutscene(_cutSceneController.CurrentCutsceneIndex);
        }
    }
}