using UnityEngine;

public class ConditionPlayAudio : Condition
{
    private MusicControl _musicControl;
    private bool isComplited;

    public ConditionPlayAudio(MusicControl musicControl)
    {
        _musicControl = musicControl;
    }

    public override void Initialization(GoalController goalController)
    {
        isComplited = false;
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }

    public override bool CheckComplited()
    {
        return isComplited;
    }

    protected override void SetSub()
    {
        _musicControl.OnChangeState += OnChangeState;
    }

    protected override void SetUnSub()
    {
        _musicControl.OnChangeState -= OnChangeState;
    }

    private void OnChangeState( bool isChangeState)
    {
        if (isChangeState)
        {
        CheckCondition();
        }
    }

    private void CheckCondition()
    {
        isComplited = true;
        SetUnSub();
        Complited();
    }
}