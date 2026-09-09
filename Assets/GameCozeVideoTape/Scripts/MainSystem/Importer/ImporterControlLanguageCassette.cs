using System;
using UnityEngine;
using Zenject;

public class ImporterControlLanguageCassette: IInitializable, IDisposable
{
    private ControlLanguage _controlLanguage;
    private ManagerCassette _managerCassette;
    private ManagerAudioItem _managerAudioItem;

    public ImporterControlLanguageCassette(ControlLanguage controlLanguage, ManagerCassette managerCassette, ManagerAudioItem managerAudioItem)
    {
        _controlLanguage = controlLanguage;
        _managerCassette = managerCassette;
        _managerAudioItem = managerAudioItem;
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
    }
}
