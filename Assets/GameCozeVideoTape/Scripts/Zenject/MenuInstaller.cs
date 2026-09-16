using TMPro;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [Header("Buttons")]
    [SerializeField] private Button _buttonNewGame;
    [SerializeField] private Button _buttonExit;


    public override void InstallBindings()
    {
        BindSub();
        //BindImporter();
    }

    //private void BindImporter()
    //{
    //    LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
    //}

    //private void LocalizationSettings_SelectedLocaleChanged(UnityEngine.Localization.Locale obj)
    //{
    //    Debug.Log($"LocalizationSettings_SelectedLocaleChanged, obj.LocaleName:{obj.LocaleName}");
    //}

    private void BindSub()
    {
        Container.BindInterfacesAndSelfTo<ImporterButtonMenuControlLogic>()
          .AsSingle()
          .WithArguments(_buttonNewGame, _buttonExit);
    }
}