using TMPro;
using UnityEngine;

public class Question_22 : ControlFeedback
{
    private TMP_InputField TMP_InputField;

    public Question_22(int id, TMP_InputField tMP_InputField) : base(id)
    {
        TMP_InputField = tMP_InputField;
    }

    protected override void Initialization()
    {
        TMP_InputField.onValueChanged.AddListener((x) => OnSelectQuestion());
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        Question_Text += TMP_InputField.text;
    }

    public override void PreSend() { SetText(); }

    private void OnSelectQuestion()
    {
        bool isComplitedInputField = TMP_InputField.text != "";

        OnComplitedQuestion?.Invoke(ID, isComplitedInputField);
    }

}