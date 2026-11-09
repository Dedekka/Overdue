using UnityEngine;
using Zenject;

public class GamePadKeyboardInstaller : MonoInstaller
{

    [SerializeField] private GamePadKeyboard _gamePadKeyboard;
    [SerializeField] private Color _primaryTextColor;
    [SerializeField] private Color _selectedColor;

    public override void InstallBindings()
    {
        BindSub();
        BindKeyboard();
    }

    private void BindSub()
    {
        Container.Bind<DataGamePadKeyboardLanguage>()
           .FromResource(PathConst.DataGamePadKeyboardLanguageAsset)
           .AsSingle();
    }

    private void BindKeyboard()
    {
        Container.Bind<GamePadKeyboard>()
         .FromInstance(_gamePadKeyboard)
         .AsSingle();

        Container.Bind<StateColor>()
          .AsSingle()
          .WithArguments(_primaryTextColor, _selectedColor);

        Container.BindInterfacesAndSelfTo<ActivatorGamePadKeyboard>()
         .AsSingle();
    }
}

public class StateColor
{
    public Color PrimaryTextColor;
    public Color SelectedColor;

    public StateColor(Color normalColor, Color selectedColor)
    {
        PrimaryTextColor = normalColor;
        SelectedColor = selectedColor;
    }
}