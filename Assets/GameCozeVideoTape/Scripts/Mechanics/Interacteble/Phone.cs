using System;
using UnityEngine;
using Zenject;

public class Phone : MonoBehaviour
{
    [SerializeField] private AnswerCall _answerCall;
    private DialogTest _dialogTest;
    private int _dialogId;

    public event Action OnStartCall;

    [Inject]
    public void Construct(DialogTest dialogTest)
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

    public void SetDialogName(int dialogId)
    {
        _answerCall.gameObject.SetActive(true);
        _dialogId = dialogId;
    }

    private void StartDialog()
    {
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
