using DG.Tweening;
using UnityEngine;
using Zenject;

public class AudioRecorderAnimation //: IInitializable
{

    private Transform _buttonPlay;
    private Transform _coverPlate;
    Sequence _changeStateCoverPlate;

    private float _timeCoverPlate;
    private float _timeButtonPlay;
    private float _delayOpen;

    Vector3 CoverPlateOpen;
    Vector3 CoverPlateCloset;
    Vector3 tempState;

    Vector3 StatePause;
    Vector3 StatePlay;

    public AudioRecorderAnimation(Transform buttonPlay, Transform coverPlate, SettingsLookItem settingsLookItem)
    {
        _buttonPlay = buttonPlay;
        _coverPlate = coverPlate;

        _timeCoverPlate = settingsLookItem.TimeCoverPlate;
        _timeButtonPlay = settingsLookItem.TimeButtonPlay;
        _delayOpen = settingsLookItem.DelayOpen;

        CoverPlateCloset = settingsLookItem.CoverPlateCloset;
        CoverPlateOpen = settingsLookItem.CoverPlateOpen;
        StatePause = Vector3.zero;
        StatePlay = settingsLookItem.StatePlay;
    }

    public void SetAudioCassette()
    {
        ChangeStateCoverPlate();
        ChangeStateButtonPlay(false);
    }

    public void ChangeStateButtonPlay(bool isButtonPlayState)
    {
        tempState = isButtonPlayState ? StatePlay : StatePause;
        _buttonPlay.DOLocalMoveY(tempState.y, _timeButtonPlay).Play();
    }

    private void ChangeStateCoverPlate()
    {
        _changeStateCoverPlate?.Kill();

        _changeStateCoverPlate = DOTween.Sequence();
        _changeStateCoverPlate.Append(_coverPlate.DOLocalRotate(CoverPlateOpen, _timeCoverPlate));
        _changeStateCoverPlate.Append(_coverPlate.DOLocalRotate(CoverPlateCloset, _timeCoverPlate).SetDelay(_delayOpen));
        _changeStateCoverPlate.Play();
    }
}