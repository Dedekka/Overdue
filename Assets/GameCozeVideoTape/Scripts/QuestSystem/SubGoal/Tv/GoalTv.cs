using System.Collections.Generic;
using UnityEngine;

public class GoalTv : Goal
{
    public GoalTv(TutorialEventSettings settings, List<Condition> conditions) : base(settings, conditions)
    {
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
    }
}