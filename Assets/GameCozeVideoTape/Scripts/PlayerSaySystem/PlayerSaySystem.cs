using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSaySystem : IInitializable, IDisposable, IStarterDialogueble
{
    private List<SayEvent> _sayEvent;
    private FactorySayEvent _factorySayEvent;
    private DialogSystem _dialogSystem;

    private int _waitDialogId;
    public event Action OnWaitDialog;

    public PlayerSaySystem(FactorySayEvent factorySayEvent, DialogSystem dialogSystem)
    {
        _factorySayEvent = factorySayEvent;
        _dialogSystem = dialogSystem;
        _waitDialogId = -1;
    }

    public void Initialize()
    {
        Initialization();
    }

    public void Dispose()
    {

    }
    //

    public void SetWaitDialog(int idDialogue)
    {
        _waitDialogId = idDialogue;
        OnWaitDialog?.Invoke();
    }

    public void ActiveDialogue()
    {
        if (_waitDialogId < 0)
        {
            Debug.Log("Not found waitdialogId");
            return;
        }
        ActiveDialogue(_waitDialogId);
        _waitDialogId = -1;
    }

    public void ActiveDialogue(int idDialogue)
    {
        bool SuccessStart = _dialogSystem.CheckDialogue(this, idDialogue);

        if (SuccessStart)
        {
            _dialogSystem.StartDialogue();
        }
        else
        {
            Debug.LogError("NOT Found Dialog");
        }
    }

    private void Initialization()
    {
        _sayEvent = _factorySayEvent.GetComplitedEvents();

        for (int i = 0; i < _sayEvent.Count; i++)
        {
            _sayEvent[i].Initialization();
        }
    }
}