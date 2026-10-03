using System.Collections.Generic;
using UnityEngine;

public class GoalPhone : Goal
{
    public GoalPhone(TutorialEventSettings settings, List<Condition> conditions) : base(settings, conditions)
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
        Debug.Log($"{this.GetType()}, CheckComplited:{CheckComplited()}");
        _goalController.ClearGoal(Settings.TutorialEventType);
    }
}
