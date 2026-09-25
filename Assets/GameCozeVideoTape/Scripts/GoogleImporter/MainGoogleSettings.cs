using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MainGoogleSettings
{
    [Header("Genre")]
    public List<GenreSettings> Genre;
    public List<GenreLanguage> GenreLanguage;
    public List<ItemLanguage> Language;
    [Header("Items")]
    public List<ItemSettings> Items;
    [Header("Dialogue")]
    public List<PresentSettings> Presents;
    public List<PresentLanguageSettings> PresentLanguage;
    public List<HistoryEventSettings> HistoryEvent;
    public List<DialogSettings> Dialogues;
    public List<DialogLanguageSettings> DialogLanguage;
    [Header("Opera")]
    public List<OperaSettings> Opera;
    public List<OperaLanguageSettings> OperaLanguage;
    [Header("Music")]
    public List<MusicCassetteSettings> Music;
    public List<MusicLanguage> MusicLanguage;

    [Header("TutorialEvent")]
    public List<TutorialEventSettings> TutorialEventLanguage;
}
