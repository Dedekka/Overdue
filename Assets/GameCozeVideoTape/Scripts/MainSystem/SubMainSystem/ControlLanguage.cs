using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using Zenject;

public class ControlLanguage : IInitializable, IDisposable
{
     private Button _buttonLanguageR;
    private Button _buttonLanguageL;
    private ControlSettings _controlSettings;
    //private TMP_Dropdown _dropDownLanguage;
    public event Action OnChangeLanguage;

    public ControlLanguage(ControlSettings controlSettings, Button buttonLanguageR, Button buttonLanguageL)
    {
        //_dropDownLanguage = dropDownLanguage;
        _buttonLanguageR = buttonLanguageR;
        _buttonLanguageL = buttonLanguageL;
        _controlSettings = controlSettings;
    }

    public void Dispose()
    {
        //_dropDownLanguage.onValueChanged.RemoveListener(ChangeLanguage);
    }

    public void Initialize()
    {
        _buttonLanguageR.onClick.AddListener(()=>ChangeLanguage(0));
        _buttonLanguageL.onClick.AddListener(()=>ChangeLanguage(1));
        //_dropDownLanguage.value = (int)_controlSettings.Language;
        //Debug.Log($"ControlLanguage, Initialize,  _dropDownLanguage.value:{_dropDownLanguage.value},_controlSettings.Language:{_controlSettings.Language} ");
        //_dropDownLanguage.onValueChanged.AddListener(ChangeLanguage);
        OnChangeLanguage?.Invoke();
        //_dropDownLanguage.onValueChanged.AddListener((_) => Debug.Log($"BindLanguage:{_}"));
    }

    private void ChangeLanguage(int language)
    {
        _controlSettings.ChangeLanguage((Language)language);
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[(int)_controlSettings.Language];
        OnChangeLanguage?.Invoke();
    }
}