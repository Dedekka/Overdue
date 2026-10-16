using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SocialPlatforms;
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
        _buttonLanguageR.onClick.RemoveAllListeners();
        _buttonLanguageL.onClick.RemoveAllListeners();
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }

    public void Initialize()
    {
        _buttonLanguageR.onClick.AddListener(() => ChangeLanguage("ru"));
        _buttonLanguageL.onClick.AddListener(() => ChangeLanguage("en"));
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;

        GetLanguage().Forget();
    }

    private void ChangeLanguage(string language)
    {
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(language);

        LocalizationSettings.SelectedLocale = locale;

        ChangeLanguage(FindLanguage(language));
    }

    private async UniTaskVoid GetLanguage()
    {
        Locale local = await LocalizationSettings.SelectedLocaleAsync;
        ChangeLanguage(FindLanguage(local.Identifier.Code));
    }

    private Language FindLanguage(string language)
    {
        Language currentLanguage = language switch
        {
            "en" => Language.en,
            "ru" => Language.ru,
            //Language.DE => DE,
            //Language.ES => ES,
            //Language.JPN => JPN,
            //Language.ZHCN => ZHCN,
            _ => throw new NotImplementedException()
        };
        return currentLanguage;
    }

    private void OnLocaleChanged(Locale locale)
    {
        ChangeLanguage(FindLanguage(locale.Identifier.Code));
    }

    private void ChangeLanguage(Language language)
    {
        _controlSettings.ChangeLanguage(language);
        OnChangeLanguage?.Invoke();
    }
}