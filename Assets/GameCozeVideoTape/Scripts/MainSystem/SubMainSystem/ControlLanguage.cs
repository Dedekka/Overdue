using Cysharp.Threading.Tasks;
using System;
using UnityEngine.Localization;
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
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
    }

    public void Initialize()
    {
        _buttonLanguageR.onClick.AddListener(() => ChangeLanguage("ru"));
        _buttonLanguageL.onClick.AddListener(() => ChangeLanguage("en"));
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;

        GetLanguage().Forget();

        //_dropDownLanguage.value = (int)_controlSettings.Language;
        //Debug.Log($"ControlLanguage, Initialize,  _dropDownLanguage.value:{_dropDownLanguage.value},_controlSettings.Language:{_controlSettings.Language} ");
        //_dropDownLanguage.onValueChanged.AddListener(ChangeLanguage);
        //OnChangeLanguage?.Invoke();
        //_dropDownLanguage.onValueChanged.AddListener((_) => Debug.Log($"BindLanguage:{_}"));
    }

    private void ChangeLanguage(string language)
    {
        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(language);

        LocalizationSettings.SelectedLocale = locale;

        _controlSettings.ChangeLanguage(FindLanguage(language));
        //LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[(int)_controlSettings.Language];
        OnChangeLanguage?.Invoke();
    }

    private async UniTaskVoid GetLanguage()
    {
        Locale local = await LocalizationSettings.SelectedLocaleAsync;
        _controlSettings.ChangeLanguage(FindLanguage(local.Identifier.Code));
        OnChangeLanguage?.Invoke();
    }

    private Language FindLanguage(string language)
    {
        Language currentLanguage = language switch
        {
            "en" => Language.En,
            "ru" => Language.Ru,
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
        _controlSettings.ChangeLanguage(FindLanguage(locale.Identifier.Code));
        OnChangeLanguage?.Invoke();
    }
}
