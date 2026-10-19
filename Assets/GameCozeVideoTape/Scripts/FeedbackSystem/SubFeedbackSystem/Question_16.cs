using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question_16 : ControlFeedback
{
    private PageMultyChoose _pageOneChoose;
    private TMP_InputField _InputField;

    public Question_16(int id, PageMultyChoose pageOneChoose, TMP_InputField tMP_InputField, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _pageOneChoose = pageOneChoose;
        _InputField = tMP_InputField;
    }

    protected override void Initialization()
    {
        _pageOneChoose.OnSelectQuestion += OnSelectQuestion;
        _InputField.onValueChanged.AddListener((x) => OnSelectQuestion());
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        int countText = 1;
        for (int i = 0; i < _sendSrings.Count; i++)
        {
            Question_Text += CheckText(countText, _pageOneChoose);
            Question_Text += " , ";
            countText++;
        }
        Question_Text += " , ";
        Question_Text += _InputField.text;
    }

    public override void PreSend() { SetText(); }

    private void OnSelectQuestion()
    {
        bool isComplitedQuestion = CheckComplitedQuestion(_pageOneChoose);
        bool isComplitedInputField = _InputField.text != "";

        Debug.Log($"Send_InputField: {_InputField.text}");

        isComplitedQuestion = isComplitedQuestion || isComplitedInputField;

        OnComplitedQuestion?.Invoke(ID, isComplitedQuestion);
    }


}