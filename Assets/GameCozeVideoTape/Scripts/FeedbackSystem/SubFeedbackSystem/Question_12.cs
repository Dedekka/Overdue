using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Question_12 : ControlFeedback
{

    private PageOneChoose _pageOneChoose;
    private TMP_InputField _InputField;

    public Question_12(int id, PageOneChoose dataQuestion_3, TMP_InputField tMP_InputField, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _pageOneChoose = dataQuestion_3;
        _InputField = tMP_InputField;
    }

    protected override void Initialization()
    {
        _pageOneChoose.ToggleBooles[0].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[0].IdToggle));
        _pageOneChoose.ToggleBooles[1].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[1].IdToggle));
        _pageOneChoose.ToggleBooles[2].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[2].IdToggle));
        _pageOneChoose.ToggleBooles[3].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[3].IdToggle));
        _pageOneChoose.ToggleBooles[4].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[4].IdToggle));
        _InputField.onValueChanged.AddListener((x) => OnSelectQuestion());
        _pageOneChoose.OnSelectQuestion += OnSelectQuestion;
    }

    protected override void Disposeble()
    {
        for (int i = 0; i < _pageOneChoose.ToggleBooles.Count; i++)
        {
            _pageOneChoose.ToggleBooles[i].Button.onClick.RemoveAllListeners();
        }
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

    private void AllDisable(int id)
    {
        _pageOneChoose.ChooseToggle(id);
    }

    private void OnSelectQuestion()
    {
        bool isComplitedQuestion = CheckComplitedQuestion(_pageOneChoose);
        bool isComplitedInputField = _InputField.text != "";

        Debug.Log($"Send_InputField: {_InputField.text}");

        isComplitedQuestion = isComplitedQuestion || isComplitedInputField;

        OnComplitedQuestion?.Invoke(ID, isComplitedQuestion);
    }
}