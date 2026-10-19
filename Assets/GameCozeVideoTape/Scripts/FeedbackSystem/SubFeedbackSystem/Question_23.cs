using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question_23 : ControlFeedback
{
    private PageOneChoose _dataQuestion;
    private TMP_InputField _InputField;

    public Question_23(int id, PageOneChoose dataQuestion_3, TMP_InputField tMP_InputField, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _dataQuestion = dataQuestion_3;
        _InputField = tMP_InputField;
    }

    protected override void Initialization()
    {
        _dataQuestion.ToggleBooles[0].Button.onClick.AddListener(() => AllDisable(_dataQuestion.ToggleBooles[0].IdToggle));
        _dataQuestion.ToggleBooles[1].Button.onClick.AddListener(() => AllDisable(_dataQuestion.ToggleBooles[1].IdToggle));
        _dataQuestion.ToggleBooles[2].Button.onClick.AddListener(() => AllDisable(_dataQuestion.ToggleBooles[2].IdToggle));
        _InputField.onValueChanged.AddListener((x) => OnSelectQuestion());
        _dataQuestion.OnSelectQuestion += OnSelectQuestion;
    }

    protected override void Disposeble()
    {
        for (int i = 0; i < _dataQuestion.ToggleBooles.Count; i++)
        {
            _dataQuestion.ToggleBooles[i].Button.onClick.RemoveAllListeners();
        }
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        int countText = 1;
        for (int i = 0; i < _sendSrings.Count; i++)
        {
            Question_Text += CheckText(countText, _dataQuestion);
            Question_Text += " , ";
            countText++;
        }
        Question_Text += " , ";
        Question_Text += _InputField.text;
    }

    private void AllDisable(int id)
    {
        _dataQuestion.ChooseToggle(id);
    }

    public override void PreSend() { SetText(); }

    private void OnSelectQuestion()
    {
        bool isComplitedQuestion = CheckComplitedQuestion(_dataQuestion);
        bool isComplitedInputField = _InputField.text != "";

        Debug.Log($"Send_InputField: {_InputField.text}");

        isComplitedQuestion = isComplitedQuestion || isComplitedInputField;

        OnComplitedQuestion?.Invoke(ID, isComplitedQuestion);
    }
}