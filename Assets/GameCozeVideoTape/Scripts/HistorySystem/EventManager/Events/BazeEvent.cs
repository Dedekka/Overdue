using System;
using UnityEngine;

[Serializable]
public class BazeEvent
{
    public int IdEventHistory;
    public int CountCassette;
}

[Serializable]
public class PresentEvent : BazeEvent
{
    public int IDCassette;
    public int IDPresent;
}

[Serializable]
public class PhoneEvent : BazeEvent
{
    public int IDDialogue;
}

[Serializable]
public class ProgressEvent
{
    public BazeEvent BazeEvent;
    public bool IsComplited;
}