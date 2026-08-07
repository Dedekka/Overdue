using FMODUnity;
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


[Serializable]
public class CharactersSettings
{
    public int Id;
    public string OriginalName;
    public string Ru;
}

[Serializable]
public class DialogLine
{
    public string Character;
    public int IdNumber;
    public string Line;
    public string SoundLine;
}

[Serializable]
public class SoundLine
{
    public string IdLine;
    public string PathFmod;
}

[Serializable]
public class PresentData
{
    public int IdPresent;
    public string NamePresent;
}

[Serializable]
public class DialogueEventData
{
    public int IdEvent;
    public string DialogueName;
    public int ID_Cassette;
    public int ID_Present;
}