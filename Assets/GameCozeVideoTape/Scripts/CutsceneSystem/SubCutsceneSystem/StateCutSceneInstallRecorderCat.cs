using UnityEngine;

public class StateCutSceneInstallRecorderCat : StateCutScene
{
    private Cat _cat;

    public StateCutSceneInstallRecorderCat(int idCutscene, PlayerStateControl playerStateControl, PlayerUi playerUi, Cat cat) : base(idCutscene, playerStateControl, playerUi)
    {
        _cat = cat;
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
        _cat.gameObject.SetActive(true);
    }
}