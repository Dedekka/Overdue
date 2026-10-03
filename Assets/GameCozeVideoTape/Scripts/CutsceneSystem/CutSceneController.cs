using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneController
{
    public int CurrentCutsceneIndex { get; private set; }
    public PlayableDirector CurrentCutscene { get; private set; }
    private Dictionary<int, PlayableDirector> cutsceneDataBase = new Dictionary<int, PlayableDirector>();
    private FactoryCutScene _factoryCutScene;


    public event Action<int> OnStartCutscene;
    public event Action OnEndCutscene;

    public CutSceneController(FactoryCutScene factoryCutScene)
    {
        _factoryCutScene = factoryCutScene;
    }

    public void Initialization()
    {
        cutsceneDataBase = _factoryCutScene.GetCutScene();
    }

    public void StartCutscene(int IDCutscene)
    {
        if (!CheckCorrectCutscene(IDCutscene)) { return; }

        ChangeCurrentCutscene(IDCutscene);
        CurrentCutsceneIndex = IDCutscene;
        ControlStateCutscene(CurrentCutscene);
    }

    //public void EndCutscene(PlayableDirector temputscene)
    //{
    //    if (temputscene != null)
    //    {
    //        temputscene.Stop();
    //        temputscene.gameObject.SetActive(false);
    //        temputscene = null;
    //    }
    //}

    private void ControlStateCutscene(PlayableDirector cutscene)
    {
        cutscene.Play();
        cutscene.stopped += OnStopped;
        OnStartCutscene?.Invoke(CurrentCutsceneIndex);
    }

    private void OnStopped(PlayableDirector cutscene)
    {
        if (CurrentCutscene == cutscene)
        {
            CurrentCutscene = null;
            OnEndCutscene?.Invoke();
        }
        cutscene.stopped -= OnStopped;
    }

    private bool CheckCorrectCutscene(int idCutscene)
    {
        Debug.Log($"CutsceneManager = {idCutscene}");
        if (!cutsceneDataBase.ContainsKey(idCutscene))
        {
            Debug.LogError($" \"{idCutscene}\" cutsceneDataBase");
            return false;
        }
        if (CurrentCutscene == cutsceneDataBase[idCutscene])
        {
            Debug.Log($"CutsceneManager activeCutscene == cutsceneDataBase[cutsceneKey]");
            return false;
        }
        return true;
    }

    private void ChangeCurrentCutscene(int IDCutscene)
    {
        CurrentCutscene = cutsceneDataBase[IDCutscene];
        foreach (var cutscene in cutsceneDataBase)
        {
            if (cutscene.Value != null) cutscene.Value.gameObject.SetActive(false);
        }
        CurrentCutscene.gameObject.SetActive(true);
    }

}

[Serializable]
public struct CutsceneStruct
{
    public string CutsceneName;
    public int IDCutscene;
    public PlayableDirector CutsceneObject;
}