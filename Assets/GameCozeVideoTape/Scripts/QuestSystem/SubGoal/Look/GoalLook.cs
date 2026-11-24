using System.Collections.Generic;
using UnityEngine;

public class GoalLook : Goal
{
    private ControlGameAnalytics _controlGameAnalytics;
    public GoalLook(TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics) : base(settings, conditions)
    {
        _controlGameAnalytics = controlGameAnalytics;
    }

    public override void Initialization(GoalController goalController)
    {
        _goalController = goalController;
        base.Initialization(goalController);
        SetSub();
        _controlGameAnalytics.SendCompliteEvent(5);
        //Debug.Log($"GoalMove Initialization");
    }

    protected override void OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        //Debug.Log($"CheckComplited:{CheckComplited()}");
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnPickUp);
    }
}
