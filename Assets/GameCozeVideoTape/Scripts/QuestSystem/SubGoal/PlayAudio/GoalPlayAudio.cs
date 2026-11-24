using System.Collections.Generic;
using UnityEngine;

public class GoalPlayAudio : Goal
{

    private ControlGameAnalytics _controlGameAnalytics;
    public GoalPlayAudio(TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics) : base(settings, conditions)
    {
        _controlGameAnalytics = controlGameAnalytics;
    }

    public override void Initialization(GoalController goalController)
    {
        base.Initialization(goalController);
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }

    protected override void OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        //Debug.Log($"CheckComplited:{CheckComplited()}");
        _goalController.ClearGoal(Settings.TutorialEventType);

        _controlGameAnalytics.SendCompliteEvent(16);
        //_goalController.ActiveGoal(TutorialEventType.OnDrop);
    }
}
