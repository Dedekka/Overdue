using UnityEngine;

public class StateCutSceneInstallRecorderCat : StateCutScene
{
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    private Cat _cat;

    public StateCutSceneInstallRecorderCat(int idCutscene, PlayerStateControl playerStateControl, PlayerUi playerUi, Cat cat, ControlFullScreenTutorial controlFullScreenTutorial) : base(idCutscene, playerStateControl, playerUi)
    {
        _cat = cat;
        _controlFullScreenTutorial = controlFullScreenTutorial;
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
        _controlFullScreenTutorial.SetPanel(5);
    }
}