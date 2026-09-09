using System;
using UnityEngine;
using UnityEngine.Video;

[Serializable]
public class MusicCassetteSettings 
{
    public string MusicName;
    public int Id;
    public string Audio;
    //public string Description;
    public int MaterialIndex;
}

[Serializable]
public class MusicLanguage
{
    public string En;
    public int Id;
    public string Ru;
    public string DE;
    public string ES;
    public string JPN;
    public string ZHCN;

    public string GetMusicLanguage(Language language)
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