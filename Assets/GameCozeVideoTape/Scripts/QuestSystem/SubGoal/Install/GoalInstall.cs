using System.Collections.Generic;
using UnityEngine;

public class GoalInstall : Goal
{
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;

    public GoalInstall(int idDialogue, TutorialEventSettings settings, List<Condition> conditions, PlayerSaySystem playerSaySystem) : base(settings, conditions)
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

    protected override void OnComplitedCondition(Condition condition)
    {
        base.OnComplitedCondition(condition);
        Debug.Log($"CheckComplited:{CheckComplited()}");
        _playerSaySystem.ActiveDialogue(_idDialogue);
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnChangeAudio);
    }
}