using System.Collections.Generic;
using UnityEngine;

public class GoalPickUp : Goal
{
    private ControlGameAnalytics _controlGameAnalytics;
    public GoalPickUp( TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics ) : base(settings, conditions)
    {
        _controlGameAnalytics = controlGameAnalytics;
    }

    public override void Initialization(GoalController goalController)
    {
        base.Initialization(goalController);
        SetSub();
        _controlGameAnalytics.SendCompliteEvent(6);
        Debug.Log($"{this.GetType()} Initialization");
    }

    protected override void OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        Debug.Log($"CheckComplited:{CheckComplited()}");
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnDrop);
    }
}
