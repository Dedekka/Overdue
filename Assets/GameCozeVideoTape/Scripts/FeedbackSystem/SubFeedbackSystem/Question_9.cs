using System.Collections.Generic;
using UnityEngine;

public class Question_9 : ControlFeedback
{

    private PageOneChoose _pageOneChoose;

    public Question_9(int id, PageOneChoose pageOneChoose, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _pageOneChoose = pageOneChoose;
    }

    protected override void Initialization()
    {
        //for (int i = 0; i < _pageOneChoose.ToggleBooles.Count; i++)
        //{
        //Debug.Log($"Initialization, ChooseToggle: {i}, ToggleBooles[i].Button.IdToggle: {_pageOneChoose.ToggleBooles[i].IdToggle}");


        _pageOneChoose.ToggleBooles[0].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[0].IdToggle));
        _pageOneChoose.ToggleBooles[1].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[1].IdToggle));
        _pageOneChoose.ToggleBooles[2].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[2].IdToggle));
        _pageOneChoose.ToggleBooles[3].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[3].IdToggle));
        _pageOneChoose.ToggleBooles[4].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[4].IdToggle));
        //}

        //_dataQuestion.Question_2_Toggle_1.onClick.AddListener(() => AllDisable(1));
        //_dataQuestion.Question_2_Toggle_2.onClick.AddListener(() => AllDisable(2));
        //_dataQuestion.Question_2_Toggle_3.onClick.AddListener(() => AllDisable(3));
        //_dataQuestion.Question_2_Toggle_4.onClick.AddListener(() => AllDisable(4));
        //_dataQuestion.Question_2_Toggle_5.onClick.AddListener(() => AllDisable(5));
    }

    protected override void Disposeble()
    {
        for (int i = 0; i < _pageOneChoose.ToggleBooles.Count; i++)
        {
            _pageOneChoose.ToggleBooles[i].Button.onClick.RemoveAllListeners();
        }

        //_dataQuestion.Question_2_Toggle_1.onClick.RemoveAllListeners();
        //_dataQuestion.Question_2_Toggle_2.onClick.RemoveAllListeners();
        //_dataQuestion.Question_2_Toggle_3.onClick.RemoveAllListeners();
        //_dataQuestion.Question_2_Toggle_4.onClick.RemoveAllListeners();
        //_dataQuestion.Question_2_Toggle_5.onClick.RemoveAllListeners();
    }

    private void SetText()
    {
        Question_Text = string.Empty;

        int countText = 1;
        for (int i = 0; i < _sendSrings.Count; i++)
        {
            Question_Text += CheckText(countText, _pageOneChoose);
            countText++;
        }
    }

    public override void PreSend() { SetText(); }

    private void AllDisable(int id)
    {
        _pageOneChoose.ChooseToggle(id);
    }
}
