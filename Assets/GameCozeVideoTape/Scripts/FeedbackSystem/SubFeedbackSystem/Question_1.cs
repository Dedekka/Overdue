using System.Collections.Generic;
using UnityEngine.UI;

public class Question_1 : ControlFeedback
{
    PageMultyChoose _dataQuestion_1;

    public Question_1(int id, PageMultyChoose dataQuestion_1, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _dataQuestion_1 = dataQuestion_1;
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
    }

    public override void PreSend() { SetText(); }
}

public class SendSring
{
    public int _idSring;
    public string _text;

    public SendSring(int idSring, string text)
    {
        _idSring = idSring;
        _text = text;
    }
}