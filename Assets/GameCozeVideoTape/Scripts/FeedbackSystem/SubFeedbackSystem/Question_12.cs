using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question_12 : ControlFeedback
{
    private PageMultyChoose _dataQuestion_1;
    private TMP_InputField Question_12_InputField_1;


    public Question_12(int id, PageMultyChoose dataQuestion_1, TMP_InputField Question_12_InputField_1, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _dataQuestion_1 = dataQuestion_1;
        this.Question_12_InputField_1 = Question_12_InputField_1;
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        int countText = 1;
        for (int i = 0; i < _sendSrings.Count; i++)
        {
            Question_Text += CheckText(countText, _dataQuestion_1);
            countText++;
        }
        Question_Text += " , ";
        Question_Text += Question_12_InputField_1.text;
    }

    public override void PreSend() { SetText(); }
}