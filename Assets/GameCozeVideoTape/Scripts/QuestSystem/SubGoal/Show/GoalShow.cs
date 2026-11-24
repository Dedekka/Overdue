using System.Collections.Generic;
using UnityEngine;

public class GoalShow : Goal
{

    private ControlGameAnalytics _controlGameAnalytics;
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    public GoalShow(TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics, ControlFullScreenTutorial controlFullScreenTutorial) : base(settings, conditions)
    {
        _controlFullScreenTutorial = controlFullScreenTutorial;
        _controlGameAnalytics = controlGameAnalytics;
    }

    public override void Initialization(GoalController goalController)
    {
        base.Initialization(goalController);
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");

        _controlGameAnalytics.SendCompliteEvent(9);
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