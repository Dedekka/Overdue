using System.Collections.Generic;
using UnityEngine;

public class GoalMove : Goal
{
    public GoalMove(TutorialEventSettings settings, List<Condition> conditions) : base(settings, conditions)
    {
    }
    
    public override void Initialization(GoalController goalController)
    {
        _goalController = goalController;
        base.Initialization(goalController);
        SetSub();
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
