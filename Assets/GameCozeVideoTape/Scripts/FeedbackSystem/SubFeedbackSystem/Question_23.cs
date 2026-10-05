using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question_23 : ControlFeedback
{
    private PageMultyChoose _dataQuestion;
    private TMP_InputField TMP_InputField;

    public Question_23(int id, PageMultyChoose dataQuestion_3, TMP_InputField tMP_InputField, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _dataQuestion = dataQuestion_3;
        TMP_InputField = tMP_InputField;
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        int countText = 1;
        for (int i = 0; i < _sendSrings.Count; i++)
        {
            Question_Text += CheckText(countText, _dataQuestion);
            countText++;
        }
        Question_Text += " , ";
        Question_Text += TMP_InputField.text;
    }

    public override void PreSend() { SetText(); }
}