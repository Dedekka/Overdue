using TMPro;
using UnityEngine;

public class Question_17 : ControlFeedback
{
    private TMP_InputField TMP_InputField;

    public Question_17(int id, TMP_InputField tMP_InputField) : base(id)
    {
        TMP_InputField = tMP_InputField;
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        Question_Text += TMP_InputField.text;
    }

    public override void PreSend() { SetText(); }

}