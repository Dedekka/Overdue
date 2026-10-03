using UnityEngine;

public class ComplitedReturnedOne : ComplitedHistoryEvent
{
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;

    public ComplitedReturnedOne(int id, int idEventHistory, int idDialogue, GoalController goalController,PlayerSaySystem playerSaySystem) : base(id, idEventHistory, goalController)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
    }
    
    public override void Complited()
    {
        _goalController.ActiveGoal(TutorialEventType.OnPresent);
        _goalController.ActiveGoal(TutorialEventType.OnReturned);
        _playerSaySystem.ActiveDialogue(_idDialogue);
    }
}
