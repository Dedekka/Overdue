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
    public int MaterialIndex;
    public string Audio;
    //public GenreVideo GenreVideo;
    public List<SubGenreSettings> SubGenreList;
}

[Serializable]
public class GenreLanguage
{
    public string GenreName;
    public int IdGenre;
    public VideoClip En_Video;
    public VideoClip Rus_Video;

    public VideoClip GetLanguage(Language language)
    {
        VideoClip currentLanguage = language switch
        {
            Language.En => En_Video,
            Language.Ru => Rus_Video,
            _ => throw new NotImplementedException()
        };
        return currentLanguage;
    }
}

[Serializable]
public class SubGenreSettings
{
    public string SubGenreName;
    public int IdSubGenre;
    public int MaterialIndex;
}

[Serializable]
public class GenreVideo
{
    public VideoClip Video;
    public string Audio;
    public int IdGenre;

    public void Set(int idGenre,VideoClip videoClip, string audio)
    {
        Video = videoClip;
        Audio = audio;
        IdGenre = idGenre;
    }
}