using DG.Tweening;
using UnityEngine;

public class CutsceneBlackScreen
{
    private CanvasGroup _blackScreen;
    private Sequence _stateBlackScreen;

    public CutsceneBlackScreen(CanvasGroup blackScreen)
    {
        _blackScreen = blackScreen;
    }

    public void ControlView(bool ActiveBlack)
    {
        _blackScreen.gameObject.SetActive(true);
        _blackScreen.alpha = ActiveBlack ? 1 : 0;
    }

    public void ActiveBlackScreen(float StartWait, float EndWait)
    {
        _blackScreen.gameObject.SetActive(true);
        _stateBlackScreen = DOTween.Sequence();
        _stateBlackScreen.Append(_blackScreen.DOFade(1, StartWait));
        _stateBlackScreen.Append(_blackScreen.DOFade(0, EndWait));
        _stateBlackScreen.Play();
    }
}