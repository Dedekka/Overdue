using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MainGoogleSettings
{
    [Header("Genre")]
    public List<GenreSettings> Genre;
    public List<ItemLanguage> Language;
    [Header("Items")]
    public List<ItemSettings> Items;
    [Header("Dialogue")]
    public List<PresentSettings> Presents;
    public List<DialogueEventData> DialogueEvent;
    public List<DialogSettings> Dialogues;
    public List<DialogLanguageSettings> DialogLanguage;
    [Header("Opera")]
    public List<OperaSettings> Opera;
    [Header("Music")]
    public List<MusicCassetteSettings> Music;
    public List<MusicLanguage> MusicLanguage;
}
