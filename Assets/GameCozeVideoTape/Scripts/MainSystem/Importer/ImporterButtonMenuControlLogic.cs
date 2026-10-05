using System;
using UnityEngine.UI;
using Zenject;

public class ImporterButtonMenuControlLogic : IInitializable, IDisposable
{
    private Button _buttonNewGame;
    private Button _buttonExit;
    private Button _buttonFeedbackMenu;
    private ControlLogic _controlLogic;

    public ImporterButtonMenuControlLogic(ControlLogic controlLogic, Button buttonNewGame, Button buttonExit, Button buttonFeedbackMenu)
    {
        _controlLogic = controlLogic;
        _buttonNewGame = buttonNewGame;
        _buttonExit = buttonExit;
        _buttonFeedbackMenu = buttonFeedbackMenu;
    }

    public void Initialize()
    {
        _buttonNewGame.onClick.AddListener(() => NewGame());
        _buttonExit.onClick.AddListener(() => Exit());
        _buttonFeedbackMenu.onClick.AddListener(() => FeedbackMenu());
    }

    public void Dispose()
    {
        _buttonNewGame.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
        _buttonFeedbackMenu.onClick.RemoveAllListeners();
    }

    private void NewGame()
    {
        _controlLogic.StartGame();
    }

    private void Exit()
    {
        _controlLogic.Exit();
    }

    private void FeedbackMenu()
    {
        _controlLogic.FeedbackMenu();
    }
}