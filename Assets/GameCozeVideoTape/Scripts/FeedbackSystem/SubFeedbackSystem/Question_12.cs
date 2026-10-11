using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question_12 : ControlFeedback
{
    private PageMultyChoose _dataQuestion_1;
    private TMP_InputField Question_12_InputField_1;


    public Question_12(int id, PageMultyChoose dataQuestion_1, TMP_InputField Question_12_InputField_1, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _dataQuestion_1 = dataQuestion_1;
        this.Question_12_InputField_1 = Question_12_InputField_1;
    }

    protected override void Initialization()
    {
        _dataQuestion_1.OnSelectQuestion += OnSelectQuestion;
        Question_12_InputField_1.onValueChanged.AddListener((x) => OnSelectQuestion());
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        int countText = 1;
        for (int i = 0; i < _sendSrings.Count; i++)
        {
            Question_Text += CheckText(countText, _dataQuestion_1);
            Question_Text += " , ";
            countText++;
        }
        Question_Text += " , ";
        Question_Text += Question_12_InputField_1.text;
    }

    public override void PreSend() { SetText(); }

    private void OnSelectQuestion()
    {
        bool isComplitedQuestion = CheckComplitedQuestion(_dataQuestion_1);
        bool isComplitedInputField = Question_12_InputField_1.text != "";

        Debug.Log($"Send_InputField: {Question_12_InputField_1.text}");

        isComplitedQuestion = isComplitedQuestion || isComplitedInputField;

        OnComplitedQuestion?.Invoke(ID, isComplitedQuestion);
    }

}