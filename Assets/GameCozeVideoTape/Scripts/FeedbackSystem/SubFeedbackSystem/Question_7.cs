using System.Collections.Generic;
using UnityEngine;

public class Question_7 : ControlFeedback
{
    private PageOneChoose _pageOneChoose;


    public Question_7(int id, PageOneChoose pageOneChoose, List<SendSring> sendSrings) : base(id, sendSrings)
    {
        _pageOneChoose = pageOneChoose;
    }

    protected override void Initialization()
    {
        _pageOneChoose.ToggleBooles[0].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[0].IdToggle));
        _pageOneChoose.ToggleBooles[1].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[1].IdToggle));
        _pageOneChoose.ToggleBooles[2].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[2].IdToggle));
        _pageOneChoose.ToggleBooles[3].Button.onClick.AddListener(() => AllDisable(_pageOneChoose.ToggleBooles[3].IdToggle));
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
    }

    public override void PreSend() { SetText(); }

    private void AllDisable(int id)
    {
        _pageOneChoose.ChooseToggle(id);
    }
}
