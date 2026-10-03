using System.Collections.Generic;
using UnityEngine;

public class GoalInstall : Goal
{
    private CutSceneController _cutSceneController;
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;

    public GoalInstall(int idDialogue, TutorialEventSettings settings, CutSceneController cutSceneController, List<Condition> conditions, PlayerSaySystem playerSaySystem) : base(settings, conditions)
    {
        _cutSceneController = cutSceneController;
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
        _cutSceneController.StartCutscene(2);
        _playerSaySystem.ActiveDialogue(_idDialogue);
        _goalController.ClearGoal(Settings.TutorialEventType);
        _goalController.ActiveGoal(TutorialEventType.OnChangeAudio);
    }
}