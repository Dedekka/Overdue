using System;
using UnityEngine;
using Zenject;

public class ControlPhoneAnswer : IDisposable, IInitializable
{
    // Мы запускаем анимацию звонка + звук на телефоне
    private Phone _phone;
    private DialogSystemCall _dialogSystemCall;
    private PhoneEvent _phoneEvent;
    private ControlGameAnalytics _controlGameAnalytics;

    public event Action OnEventComplited;

    public ControlPhoneAnswer(Phone phone, DialogSystemCall dialogSystemCall, ControlGameAnalytics controlGameAnalytics)
    {
        _phone = phone;
        _dialogSystemCall = dialogSystemCall;
        _controlGameAnalytics = controlGameAnalytics;
    }

    public void Initialize()
    {
        _dialogSystemCall.OnStateDialog += OnStateDialog; 
    }

    public void Dispose()
    {
        _dialogSystemCall.OnStateDialog -= OnStateDialog; 
    }

    public void SetEvent(PhoneEvent phoneEvent)
    {
        _phoneEvent = phoneEvent;
        _controlGameAnalytics.SendPhoneEvent(phoneEvent.IdEventHistory);
        ActiveEvent();
    }

    private void ActiveEvent()
    {
        _phone.SetDialogName(_phoneEvent.IDDialogue);
        _phone.ActiveCallEffect();
    }

    private void OnStateDialog(bool isComplited)
    {
        if (isComplited) { return; }
        Debug.Log($"ControlPhoneAnswer, OnStateDialog: isComplited");
        OnEventComplited?.Invoke();
    }

}