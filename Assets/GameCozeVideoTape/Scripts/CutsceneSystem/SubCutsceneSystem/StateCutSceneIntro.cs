public class StateCutSceneIntro : StateCutScene
{
    public StateCutSceneIntro(int idCutscene, PlayerStateControl playerStateControl, PlayerUi playerUi) : base(idCutscene, playerStateControl, playerUi)
    {
    }

    public override void StartCutscene()
    {
        _playerStateControl.ChangeStateControlPlayer(false);
        _playerUi.ChangeOtherGoup(false);
    }

    public override void EndCutscene()
    {
        _playerStateControl.ChangeStateControlPlayer(true);
        _playerUi.ChangeOtherGoup(true);
    }
}
