using System.Collections.Generic;
using UnityEngine;

public class GoalTv : Goal
{

    private ControlGameAnalytics _controlGameAnalytics;
    public GoalTv(TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics) : base(settings, conditions)
    {
        _controlGameAnalytics = controlGameAnalytics;
    }
    
    public override void Initialization(GoalController goalController)
    {
        base.Initialization(goalController);
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");

        _controlGameAnalytics.SendCompliteEvent(10);
    }

    protected override void OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        _goalController.ClearGoal(Settings.TutorialEventType);
    }
}