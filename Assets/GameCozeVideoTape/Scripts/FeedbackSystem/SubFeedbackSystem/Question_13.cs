using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question_13 : ControlFeedback
{
    private PageOneChoose _dataQuestion_1;

    public Question_13(int id, PageOneChoose dataQuestion_1, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _dataQuestion_1 = dataQuestion_1;
    }

    protected override void Initialization()
    {

        _dataQuestion_1.ToggleBooles[0].Button.onClick.AddListener(() => AllDisable(_dataQuestion_1.ToggleBooles[0].IdToggle));
        _dataQuestion_1.ToggleBooles[1].Button.onClick.AddListener(() => AllDisable(_dataQuestion_1.ToggleBooles[1].IdToggle));
        _dataQuestion_1.ToggleBooles[2].Button.onClick.AddListener(() => AllDisable(_dataQuestion_1.ToggleBooles[2].IdToggle));
        _dataQuestion_1.ToggleBooles[3].Button.onClick.AddListener(() => AllDisable(_dataQuestion_1.ToggleBooles[3].IdToggle));
        _dataQuestion_1.ToggleBooles[4].Button.onClick.AddListener(() => AllDisable(_dataQuestion_1.ToggleBooles[4].IdToggle));
        _dataQuestion_1.OnSelectQuestion += OnSelectQuestion;
    }

    protected override void Disposeble()
    {
        for (int i = 0; i < _dataQuestion_1.ToggleBooles.Count; i++)
        {
            _dataQuestion_1.ToggleBooles[i].Button.onClick.RemoveAllListeners();
        }
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

    private void OnSelectQuestion()
    {
        bool isComplitedQuestion = CheckComplitedQuestion(_dataQuestion_1);

        OnComplitedQuestion?.Invoke(ID, isComplitedQuestion);
    }

    private void AllDisable(int id)
    {
        _dataQuestion_1.ChooseToggle(id);
    }
}
