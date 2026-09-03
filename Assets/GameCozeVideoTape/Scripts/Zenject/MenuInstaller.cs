using System;
using TMPro;
using UnityEngine;
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
    }

    private void BindSub()
    {
        Container.BindInterfacesAndSelfTo<ImporterButtonMenuControlLogic>()
          .AsSingle()
          .WithArguments(_buttonNewGame, _buttonExit);
    }
}