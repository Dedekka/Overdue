using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question_27 : ControlFeedback
{
    private PageMultyChoose _dataQuestion;
    private TMP_InputField _InputField;

    public Question_27(int id, PageMultyChoose dataQuestion_3, TMP_InputField tMP_InputField, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _dataQuestion = dataQuestion_3;
        _InputField = tMP_InputField;
    }

    protected override void Initialization()
    {
        _dataQuestion.OnSelectQuestion += OnSelectQuestion;
        _InputField.onValueChanged.AddListener((x) => OnSelectQuestion());
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