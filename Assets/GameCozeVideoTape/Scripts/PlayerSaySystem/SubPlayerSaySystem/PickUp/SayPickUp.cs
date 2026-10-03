using UnityEngine;

public class SayPickUp : SayEvent
{
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;
    public SayPickUp(int id, int idDialogue, ConditionSayEvent conditionSayEvent, PlayerSaySystem playerSaySystem) : base(id, conditionSayEvent)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
    }

    protected override void Complited()
    {
        _playerSaySystem.ActiveDialogue(_idDialogue);
    }
}
