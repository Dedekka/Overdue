using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

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
}

[Serializable]
public class GenreSettings
{
    public string GenreName;
    public int IdGenre;
    public List<SubGenreSettings> SubGenreList;
}

[Serializable]
public class SubGenreSettings
{
    public string SubGenreName;
    public int IdSubGenre;
}