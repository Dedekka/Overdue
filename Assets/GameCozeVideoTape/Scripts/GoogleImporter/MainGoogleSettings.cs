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
    public List<PresentData> Presents;
    public List<DialogueEventData> DialogueEvent;
    public List<DialogSettings> Dialogues;
}