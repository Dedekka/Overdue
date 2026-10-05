using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public abstract class ControlFeedback : IInitializable, IDisposable
{
    protected List<SendSring> _sendSrings;
    public int ID;
    public string Question_Text = "";

    public ControlFeedback(int id, List<SendSring> sendSrings )
    {
        ID = id;
        _sendSrings = sendSrings;
    }

    protected ControlFeedback(int id)
    {
        ID = id;
    }

    public void Initialize()
    {
        Initialization();
    }

    public void Dispose()
    {
        Disposeble();
    }

    public void Send()
    {
        PreSend();
    }

    protected string CheckText(int id, IPage page)
    {
        SendSring tempSendSring = _sendSrings.Find((x) => x._idSring == id);
        string temp_Text = tempSendSring == null ? "" : tempSendSring._text;
        string question_Text;

        question_Text = page.CheckImage(id) ? $"{temp_Text}" : "";

        return question_Text;
    }


    protected virtual void Initialization() { }
    public virtual void PreSend() { }
    protected virtual void Disposeble() { }
}