using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class ImporterButtonPauseMenuControlLogic : IInitializable, IDisposable
{
    private Button _buttonBackMenu;
    private Button _buttonExit;
    private ControlLogic _controlLogic;

    public ImporterButtonPauseMenuControlLogic(ControlLogic controlLogic, Button buttonBackMenu, Button buttonExit)
    {
        _controlLogic = controlLogic;
        _buttonBackMenu = buttonBackMenu;
        _buttonExit = buttonExit;
    }

    public void Dispose()
    {
        _buttonBackMenu.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }

    public void Initialize()
    {
        _buttonBackMenu.onClick.AddListener(() => BackMenu());
        _buttonExit.onClick.AddListener(() => Exit());
    }

    private void BackMenu()
    {
        _controlLogic.BackMenu();
    }

    private void Exit()
    {
        _controlLogic.Exit();
    }
}