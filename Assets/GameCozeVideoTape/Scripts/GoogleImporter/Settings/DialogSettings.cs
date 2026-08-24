using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogSettings
{
    public string DialogueName;
    public int Id;
    public string NameCharacter;
    public string Original_Title;
    public string Present;
    public List<DialogLine> DialogLines;
    public DialogueEventData DialogueEventData;
}


//[Serializable]
//public class CharactersSettings
//{
//    public int Id;
//    public string OriginalName;
//    public string Ru;
//}

[Serializable]
public class DialogLine : IDialoguebleLine
{
    [field: SerializeField] public string Character { get; set; }
    [field: SerializeField] public string Line { get; set; }
    public int IdNumber;
    public string SoundLine;
}

[Serializable]
public class SoundLine
{
    public string IdLine;
    public string PathFmod;
}

[Serializable]
public class PresentSettings
{
    public string NamePresent;
    public int IdPresent;
    public int MaterialIndex;
}

[Serializable]
public class DialogueEventData
{
    public int IdEvent;
    public string DialogueName;
    public int IDCassette;
    public int IDPresent;
}