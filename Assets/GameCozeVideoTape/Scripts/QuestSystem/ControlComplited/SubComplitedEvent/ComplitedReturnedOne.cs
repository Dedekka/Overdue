using UnityEngine;

public class ComplitedReturnedOne : ComplitedHistoryEvent
{
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;

    public ComplitedReturnedOne(int id, int idEventHistory, int idDialogue, GoalController goalController,PlayerSaySystem playerSaySystem, ControlFullScreenTutorial controlFullScreenTutorial) : base(id, idEventHistory, goalController)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
        _controlFullScreenTutorial = controlFullScreenTutorial;
    }
    
    public override void Complited()
    {
        _goalController.ActiveGoal(TutorialEventType.OnPresent);
        _goalController.ActiveGoal(TutorialEventType.OnReturned);
        _controlFullScreenTutorial.SetPanel(4);
        _playerSaySystem.SetWaitDialog(_idDialogue);
    }
}
