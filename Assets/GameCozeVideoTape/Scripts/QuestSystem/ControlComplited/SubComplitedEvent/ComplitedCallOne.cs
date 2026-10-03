using UnityEngine;

public class ComplitedCallOne : ComplitedHistoryEvent
{
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;

    public ComplitedCallOne(int id, int idEventHistory, int idDialogue, GoalController goalController, PlayerSaySystem playerSaySystem) : base(id, idEventHistory, goalController)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
    }

    public override void Complited()
    {
        _goalController.ClearGoal(TutorialEventType.OnMove);
        _goalController.ClearGoal(TutorialEventType.OnPickUp);
        _goalController.ClearGoal(TutorialEventType.OnDrop);
        _goalController.ClearGoal(TutorialEventType.OnScroll);
        _goalController.ClearGoal(TutorialEventType.OnShow);
        _goalController.ClearGoal(TutorialEventType.OnTv);
        _goalController.ActiveGoal(TutorialEventType.OnPhone);
        _playerSaySystem.ActiveDialogue(_idDialogue);

    }
}
