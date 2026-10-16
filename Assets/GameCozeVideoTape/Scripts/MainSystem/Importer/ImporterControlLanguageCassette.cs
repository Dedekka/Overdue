using System;
using UnityEngine;
using Zenject;

public class ImporterControlLanguageCassette: IInitializable, IDisposable
{
    private ControlLanguage _controlLanguage;
    private ManagerCassette _managerCassette;
    private ManagerAudioItem _managerAudioItem;
    private GoalController _goalController;
    private ControlRackLanguage _controlRackLanguage;
    private PlayerInventory _playerInventory;

    
    public ImporterControlLanguageCassette(ControlLanguage controlLanguage, ManagerCassette managerCassette, ManagerAudioItem managerAudioItem, GoalController goalController, ControlRackLanguage controlRackLanguage, PlayerInventory playerInventory)
    {
        _controlLanguage = controlLanguage;
        _managerCassette = managerCassette;
        _managerAudioItem = managerAudioItem;
        _goalController = goalController;
        _controlRackLanguage = controlRackLanguage;
        _playerInventory = playerInventory;
    }

    public void Initialize()
    {
        _controlLanguage.OnChangeLanguage += OnChangeLanguage;
    }

    public void Dispose()
    {
        _controlLanguage.OnChangeLanguage -= OnChangeLanguage;
    }

    private void OnChangeLanguage()
    {
        _managerCassette.ChangeLanguage();
        _managerAudioItem.ChangeLanguage();
        _goalController.ChangeLanguage();
        _controlRackLanguage.ChangeLanguage();
        _playerInventory.ChangeLanguage();
    }
}