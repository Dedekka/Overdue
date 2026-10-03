using System.Collections.Generic;
using UnityEngine;

public class GoalPresent : Goal
{
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;
    public GoalPresent(int idDialogue,TutorialEventSettings settings, List<Condition> conditions, PlayerSaySystem playerSaySystem) : base(settings, conditions)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
    }

    public override void Initialization(GoalController goalController)
    {
        base.Initialization(goalController);
        SetSub();
        Debug.Log($"{this.GetType()} Initialization");
    }

    protected override void  OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        Debug.Log($"{this.GetType()}, CheckComplited:{CheckComplited()}");
        _playerSaySystem.ActiveDialogue(_idDialogue);
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnInstall);
    }
}
