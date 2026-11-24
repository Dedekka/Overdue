using System.Collections.Generic;
using UnityEngine;

public class GoalChangeAudio : Goal
{

    private ControlGameAnalytics _controlGameAnalytics;
    public GoalChangeAudio(TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics) : base(settings, conditions)
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
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnPlayAudio);
        _controlGameAnalytics.SendCompliteEvent(15);
    }
}