using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

public abstract class ControlFeedback : IInitializable, IDisposable
{
    public int ID;
    public string Question_Text = "";

    public ControlFeedback(int id )
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

   

    protected abstract void Initialization();
    public virtual void PreSend() { }
    protected abstract void Disposeble();
}