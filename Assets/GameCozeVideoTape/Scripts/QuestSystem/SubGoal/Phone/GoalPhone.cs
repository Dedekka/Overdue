using System.Collections.Generic;
using UnityEngine;

public class GoalPhone : Goal
{

    private ControlGameAnalytics _controlGameAnalytics;
    private ControlSteamAchievement _controlSteamAchievement;
    public GoalPhone(TutorialEventSettings settings, List<Condition> conditions, ControlGameAnalytics controlGameAnalytics, ControlSteamAchievement controlSteamAchievement) : base(settings, conditions)
    {
        _controlSteamAchievement = controlSteamAchievement;
        _controlGameAnalytics = controlGameAnalytics;
    }
    
    public override void Initialization(GoalController goalController)
    {
        base.Initialization(goalController);
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
        _controlGameAnalytics.SendCompliteEvent(11);
    }



    protected override void OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        Debug.Log($"{this.GetType()}, CheckComplited:{CheckComplited()}");

        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_24);
        _goalController.ClearGoal(Settings.TutorialEventType);
    }
}
