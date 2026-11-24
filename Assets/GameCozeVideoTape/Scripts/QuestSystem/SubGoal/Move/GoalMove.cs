using System.Collections.Generic;

public class GoalMove : Goal
{
    private ControlGameAnalytics _controlGameAnalytics;
    public GoalMove(TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics) : base(settings, conditions)
    {
        _controlGameAnalytics = controlGameAnalytics;
    }

    public override void Initialization(GoalController goalController)
    {
        _goalController = goalController;
        base.Initialization(goalController);
        SetSub();
        _controlGameAnalytics.SendCompliteEvent(4);
    }

    protected override void OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnLook);
    }
}
