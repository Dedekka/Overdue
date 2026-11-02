using System.Collections.Generic;
using UnityEngine;

public class GoalShow : Goal
{
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    public GoalShow(TutorialEventSettings settings, List<Condition> conditions, ControlFullScreenTutorial controlFullScreenTutorial) : base(settings, conditions)
    {
        _controlFullScreenTutorial = controlFullScreenTutorial;
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
        Debug.Log($"CheckComplited:{CheckComplited()}");
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnTv);
        _controlFullScreenTutorial.SetPanel(2);
    }
}