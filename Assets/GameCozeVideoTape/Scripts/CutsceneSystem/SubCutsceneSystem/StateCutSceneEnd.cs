using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class StateCutSceneEnd : StateCutScene
{
    private Cat _cat;
    private ControlLogic _ñontrolLogic;
    private AudioManager _audioManager;
    private GoalController _goalController;
    private CutsceneBlackScreen _cutsceneBlackScreen;
    private ControlSettings _controlSettings;
    private float _startWait;
    private float _endWait;

    public StateCutSceneEnd(int idCutscene, float StartWait, float EndWait, ControlLogic ñontrolLogic, PlayerStateControl playerStateControl, CutsceneBlackScreen cutsceneBlackScreen, PlayerUi playerUi, ControlSettings controlSettings, AudioManager audioManager, Cat cat, GoalController goalController) : base(idCutscene, playerStateControl, playerUi)
    {
        _goalController = goalController;
         _cutsceneBlackScreen = cutsceneBlackScreen;
        _startWait = StartWait;
        _endWait = EndWait;
        _ñontrolLogic = ñontrolLogic;
        _controlSettings = controlSettings;
        _audioManager = audioManager;
        _cat = cat;
    }

    public override void StartCutscene()
    {
        _audioManager.StopMusic();
        _cutsceneBlackScreen.ControlView(true);
        _cutsceneBlackScreen.ActiveBlackScreen(_startWait, _endWait);
        _playerStateControl.ChangeStateControlPlayer(false);
        _playerUi.ChangeOtherGoup(false);
        _cat.gameObject.SetActive(false);
        _goalController.ClearGoal(TutorialEventType.OnExit);
    }

    public override void EndCutscene()
    {
        WaitTimer().Forget();
    }

    private async UniTask WaitTimer()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3));

        if (_controlSettings.IsComplitedFeedback)
        {
        _ñontrolLogic.BackMenu();
        }
        else
        {
        _ñontrolLogic.FeedbackMenu();
        }
    }
}