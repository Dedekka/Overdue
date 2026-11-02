using UnityEngine;

public class ComplitedCallOne : ComplitedHistoryEvent
{
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;

    public ComplitedCallOne(int id, int idEventHistory, int idDialogue, GoalController goalController, PlayerSaySystem playerSaySystem, ControlFullScreenTutorial controlFullScreenTutorial) : base(id, idEventHistory, goalController)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
        _controlFullScreenTutorial = controlFullScreenTutorial;
    }

    public override void Complited()
    {
        _goalController.ClearGoal(TutorialEventType.OnMove);
        _goalController.ClearGoal(TutorialEventType.OnPickUp);
        _goalController.ClearGoal(TutorialEventType.OnDrop);
        _goalController.ClearGoal(TutorialEventType.OnScroll);
        _goalController.ClearGoal(TutorialEventType.OnShow);
        _goalController.ClearGoal(TutorialEventType.OnTv);
        _goalController.ClearGoal(TutorialEventType.OnLook);
        _goalController.ActiveGoal(TutorialEventType.OnPhone);
        _playerSaySystem.SetWaitDialog(_idDialogue);
        _controlFullScreenTutorial.SetPanel(3);
    }
}
