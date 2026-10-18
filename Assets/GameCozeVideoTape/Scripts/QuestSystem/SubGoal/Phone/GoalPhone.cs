using System.Collections.Generic;
using UnityEngine;

public class GoalPhone : Goal
{
    private ControlSteamAchievement _controlSteamAchievement;
    public GoalPhone(TutorialEventSettings settings, List<Condition> conditions, ControlSteamAchievement controlSteamAchievement) : base(settings, conditions)
    {
        _controlSteamAchievement = controlSteamAchievement;
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

        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_24);
        _goalController.ClearGoal(Settings.TutorialEventType);
    }
}
