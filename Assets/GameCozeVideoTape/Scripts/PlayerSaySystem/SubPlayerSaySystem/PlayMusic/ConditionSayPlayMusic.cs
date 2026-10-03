using UnityEngine;

public class ConditionSayPlayMusic : ConditionSayEvent
{
    private MusicControl _musicControl;

    public ConditionSayPlayMusic(MusicControl musicControl)
    {
        _musicControl = musicControl;
    }

    public override void Initialization()
    {
        SetSub();
    }

    private void SetSub()
    {
        _musicControl.OnChangeState += OnChangeState;
    }

    private void SetUnSub()
    {
        _musicControl.OnChangeState -= OnChangeState;
    }

    private void OnChangeState(bool _isPlaying)
    {
        if (_isPlaying)
        {
            SetUnSub();
            Complited();
        }
    }
}