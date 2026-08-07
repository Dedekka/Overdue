using System;
using UnityEngine;

public class AnswerCall : BazeInteracteble
{
    public event Action OnCall;

    protected override void Interact()
    {
        OnCall?.Invoke();
    }
}
