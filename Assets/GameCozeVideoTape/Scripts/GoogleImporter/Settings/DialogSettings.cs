using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogSettings
{
    public string DialogueName;
    public int Id;
    public string NameCharacter;
    //public string Original_Title;
    //public string Present;
    public List<SoundLine> SoundLine;
    //public DialogueEventData DialogueEventData;
}



[Serializable]
public class DialogLanguageSettings
{
    public string DialogueName;
    public int Id;
    public List<DialogLine> En_DialogLines;
    public List<DialogLine> Rus_DialogLines;

    public List<DialogLine> GetLanguage(Language language)
    {
        List<DialogLine> currentLanguage = language switch
        {
            Language.En => En_DialogLines,
            Language.Ru => Rus_DialogLines,
            _ => throw new NotImplementedException()
        };
        return currentLanguage;
    }
}

[Serializable]
public class DialogLine : IDialoguebleLine
{
    [field: SerializeField] public string Character { get; set; }
    [field: SerializeField] public string Line { get; set; }
    public int IdNumber;
    //public string SoundLine;
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
public class PresentLanguageSettings
{
    public string En_NamePresent;
    public string Rus_NamePresent;
    public int IdPresent;
}

[Serializable]
public class DialogueEventData
{
    public int IdEvent;
    public string DialogueName;
    public int IDCassette;
    public int IDPresent;
}