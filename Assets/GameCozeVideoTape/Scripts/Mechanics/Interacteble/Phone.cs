using FMODUnity;
using System;
using UnityEngine;
using Zenject;

public class Phone : MonoBehaviour
{
    [SerializeField] private AnswerCall _answerCall;
    //[SerializeField] private StudioEventEmitter _eventEmitter;
    private DialogCall _dialogTest;
    private int _dialogId;

    public event Action OnStartCall;

    [Inject]
    public void Construct(DialogCall dialogTest)
    {
        _dialogTest = dialogTest;
    }

    private void OnEnable()
    {
        _answerCall.OnCall += StartDialog;
        _answerCall.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        _answerCall.OnCall -= StartDialog;
    }

    public void ActiveCallEffect()
    {
        Debug.Log("Phone, ActiveCallEffect");
        // Класс отвечающий за эфекты телефона 
        // Вкл эффекты

    }

    public void SetDialogName(int dialogId)
    {
        _answerCall.gameObject.SetActive(true);
        _dialogId = dialogId;
    }

    private void StartDialog()
    {
        // Класс отвечающий за эфекты телефона 
        // Выкл эффектыы

        bool successStartDialog = _dialogTest.StartDialog(_dialogId);
        CheckSuccessCall(successStartDialog);
    }

    private void CheckSuccessCall(bool successStartDialog)
    {
        if (successStartDialog)
        {
            OnStartCall?.Invoke();
            _answerCall.gameObject.SetActive(false);
        }
    }
}
