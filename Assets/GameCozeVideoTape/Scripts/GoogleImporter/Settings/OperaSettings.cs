using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[Serializable]
public class OperaSettings
{
    public string OperaName; // "Episode_" + Id = OperaName
    public int Id;
    public int Id_Cassette;
    public int Id_Slot;
    public string Original_Title;
    public string Audio;
    //public VideoClip Video;
    //public Subtitles Subtitles;
}

[Serializable]
public class OperaLanguageSettings
{
    public string OperaName; // "Episode_" + Id = OperaName
    public int Id;
    public int Id_Cassette;
    public Subtitles En_Subtitles;
    public Subtitles Rus_Subtitles;
    //public VideoClip En_Video;
    //public VideoClip Rus_Video;


    public Subtitles GetLanguage(Language language)
    {
        Subtitles subtitles = language switch
        {
            Language.En => En_Subtitles,
            Language.Ru => Rus_Subtitles,
            _ => throw new NotImplementedException()
        };
        return subtitles;
    }

}

[Serializable]
public class Subtitles
{
    public float TimeStart;
    public SubtitlesLine DialogLine;
    public VideoClip Video;
}

[Serializable]
public class SubtitlesLine : IDialoguebleLine
{
    [field: SerializeField] public string Character { get; set; }
    [field: SerializeField] public string Line { get; set; }
}