using NUnit.Framework;
using SaveLoadSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[Serializable]
public class ItemSettings 
{
    public string Original_Title;
    public int Id;
    public int IdGenre;
    public int IdSubGenre;
    public string Material;
    public int MaterialIndex;
}

[Serializable]
public class ItemLanguage
{
    public string Original_Title;
    public int Id;
    public string En;
    public string Ru;
    public string DE;
    public string ES;
    public string JPN;
    public string ZHCN;

    public string GetLanguage(Language language)
    {
        string currentLanguage = language switch
        {
            Language.En => En,
            Language.Ru => Ru,
            Language.DE => DE,
            Language.ES => ES,
            Language.JPN => JPN,
            Language.ZHCN => ZHCN,
            _ => throw new NotImplementedException()
        };
        return currentLanguage;
    }
}

[Serializable]
public class GenreSettings
{
    public string GenreName;
    public int IdGenre;
    public GenreVideo GenreVideo;
    public List<SubGenreSettings> SubGenreList;
}

[Serializable]
public class SubGenreSettings
{
    public string SubGenreName;
    public int IdSubGenre;
}

[Serializable]
public class GenreVideo
{
    public VideoClip Video;
    public string Audio;
    public int IdGenre;
}