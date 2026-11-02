using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using Zenject;

public class ImporterFullScreenTutorialLookItemEffects : IDisposable, IInitializable
{
    private LookItemEffects _lookItemEffects;
    private ControlFullScreenTutorial _controlFullScreenTutorial;
    public ImporterFullScreenTutorialLookItemEffects(LookItemEffects lookItemEffects, ControlFullScreenTutorial controlFullScreenTutorial)
    {
        _lookItemEffects = lookItemEffects;
        _controlFullScreenTutorial = controlFullScreenTutorial;
    }

    public void Initialize()
    {
        _controlFullScreenTutorial.OnStateFullScreenTutorial += OnStateFullScreenTutorial;
    }

  
    public void Dispose()
    { 
        _controlFullScreenTutorial.OnStateFullScreenTutorial -= OnStateFullScreenTutorial;
    }

    private void OnStateFullScreenTutorial(bool isActive)
    {
        _lookItemEffects.ActiveEffects(isActive);
    }

}