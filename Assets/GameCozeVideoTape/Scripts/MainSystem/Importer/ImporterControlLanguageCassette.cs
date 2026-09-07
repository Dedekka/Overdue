using System;
using UnityEngine;
using Zenject;

public class ImporterControlLanguageCassette: IInitializable, IDisposable
{
    private ControlLanguage _controlLanguage;
    private ManagerCassette _managerCassette;

    public ImporterControlLanguageCassette(ControlLanguage controlLanguage, ManagerCassette managerCassette)
    {
        _controlLanguage = controlLanguage;
        _managerCassette = managerCassette;
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
    }
}
