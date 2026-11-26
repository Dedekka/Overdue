public class StateCutScenePreEnd : StateCutScene
{
    private GoalController _goalController;
    private TriggerCutscene _triggerCutscene;
    public StateCutScenePreEnd(int idCutscene, PlayerStateControl playerStateControl, TriggerCutscene triggerCutscene, PlayerUi playerUi, GoalController goalController) : base(idCutscene, playerStateControl, playerUi)
    {
        _goalController = goalController;
        _triggerCutscene = triggerCutscene;
    }

    public override void StartCutscene()
    {
        _playerStateControl.ChangeStateControlPlayer(false);
    }

    public override void EndCutscene()
    {
        _playerStateControl.ChangeStateControlPlayer(true);
        _goalController.ActiveGoal(TutorialEventType.OnExit);
        _triggerCutscene.gameObject.SetActive(true);
    }
}