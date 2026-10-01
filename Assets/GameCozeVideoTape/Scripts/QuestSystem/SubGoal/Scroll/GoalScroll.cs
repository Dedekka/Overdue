using System.Collections.Generic;
using UnityEngine;

public class GoalScroll : Goal
{
    public GoalScroll(TutorialEventSettings settings, List<Condition> conditions) : base(settings, conditions)
    {
    }

    public override void Initialization(GoalController goalController)
    {
        base.Initialization(goalController);
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }


    protected override void OnComplitedCondition()
    {
        Debug.Log($"CheckComplited:{CheckComplited()}");
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnShow);
    }
}
