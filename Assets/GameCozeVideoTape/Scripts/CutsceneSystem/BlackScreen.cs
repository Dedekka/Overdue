using DG.Tweening;
using UnityEngine;
using Zenject;

public class BlackScreen : MonoBehaviour
{
    private CutsceneBlackScreen _cutsceneBlackScreen;
    private float _startWait;
    private float _endWait;


    [Inject]
    public void Construct(CutsceneBlackScreen cutsceneBlackScreen)
    {
        _cutsceneBlackScreen = cutsceneBlackScreen;
    }

    public void ControlView(bool ActiveBlack)
    {
        _cutsceneBlackScreen.ControlView(ActiveBlack);
    }

    public void ActiveBlackScreen()
    {
        _cutsceneBlackScreen.ActiveBlackScreen(_startWait, _endWait);
    }

    public void SetStartWait(float startWait)
    {
        _startWait = startWait;
    }

    public void SetEndWait(float endWait)
    {
        _endWait = endWait;
    }
}
