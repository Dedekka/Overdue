using UnityEngine;

public class ComplitedDemoEnd : ComplitedHistoryEvent
{
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;

    public ComplitedDemoEnd(int id, int idEventHistory, int idDialogue, GoalController goalController, PlayerSaySystem playerSaySystem) : base(id, idEventHistory, goalController)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
    }

    public override void Complited()
    {
        _playerSaySystem.ActiveDialogue(_idDialogue);
    }
}