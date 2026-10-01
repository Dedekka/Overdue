using UnityEngine;

public class ConditionChangeAudio : Condition
{
    private AudioCassettsSystem _listenerAudioRecorder;
    private bool isComplited;

    public override void Initialization(GoalController goalController)
    {
        _listenerAudioRecorder = goalController.GoalContext.ListenerAudioRecorder.AudioCassettsSystem;
        isComplited = false;
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }

    public override bool CheckComplited()
    {
        return isComplited;
    }

    private void SetSub()
    {
        _listenerAudioRecorder.OnChangeAudio += OnChangeAudio;
    }

    private void SetUnSub()
    {
        _listenerAudioRecorder.OnChangeAudio -= OnChangeAudio;
    }

    private void OnChangeAudio()
    {
        CheckCondition();
    }

    private void CheckCondition()
    {
        isComplited = true;
        SetUnSub();
        Complited();
    }
}