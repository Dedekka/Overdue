public class SayCorrectInstall : SayEvent
{
    private ControlSteamAchievement _controlSteamAchievement;
    private PlayerSaySystem _playerSaySystem;
    private int _idDialogue;
    public SayCorrectInstall(int id, int idDialogue, ConditionSayEvent conditionSayEvent, PlayerSaySystem playerSaySystem, ControlSteamAchievement controlSteamAchievement) : base(id, conditionSayEvent)
    {
        _playerSaySystem = playerSaySystem;
        _idDialogue = idDialogue;
        _controlSteamAchievement = controlSteamAchievement;
    }

    protected override void Complited()
    {
        _playerSaySystem.ActiveDialogue(_idDialogue);
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_1);
        // Вызов первой очивки
    }
}
