using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ImporterButtonMenuControlLogic : IInitializable
{
    private Button _buttonNewGame;
    private Button _buttonExit;
    private ControlLogic _controlLogic;
    
    public ImporterButtonMenuControlLogic(ControlLogic controlLogic, Button buttonNewGame, Button buttonExit)
    {
        _controlLogic = controlLogic;
        _buttonNewGame = buttonNewGame;
        _buttonExit = buttonExit;
    }

    public void Initialize()
    {
        _buttonNewGame.onClick.AddListener(() => NewGame());
        _buttonExit.onClick.AddListener(() => Exit());
    }

    private void NewGame()
    {
        _controlLogic.StartGame();
    }

    private void Exit()
    {
        _controlLogic.Exit();
    }
}