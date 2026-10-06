using System.Collections.Generic;
using UnityEngine.Playables;
using Zenject;

public class FactoryCutScene
{
    private List<CutsceneStruct> _cutscenes;
    private List<StateCutScene> _stateCutScenes;
    private DiContainer _container;

    public FactoryCutScene(List<CutsceneStruct> cutscenes,DiContainer diContainer)
    {
        _cutscenes = cutscenes;
        _container = diContainer;
    }

    public Dictionary<int, PlayableDirector> GetCutScene()
    {
        Dictionary<int, PlayableDirector> cutsceneDataBase = new Dictionary<int, PlayableDirector>();
        for (int i = 0; i < _cutscenes.Count; i++)
        {
            PlayableDirector temp = _cutscenes[i].CutsceneObject;
            temp.gameObject.SetActive(false);
            cutsceneDataBase.Add(_cutscenes[i].IDCutscene, temp);
        }
        return cutsceneDataBase;
    }

    public List<StateCutScene> GetStateCutScenes()
    {
        List<StateCutScene> stateCutScenes = new List<StateCutScene>()
        {
            _container.Instantiate<StateCutSceneIntro>(new object[] {1}),
            _container.Instantiate<StateCutSceneInstallRecorderCat>(new object[] {2}),
            _container.Instantiate<StateCutSceneEnd>(new object[] {3,1f,2f}) 
            //StateCutSceneIntro
        };

        return stateCutScenes;
    }

}

