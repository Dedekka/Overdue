using System;


[Serializable]
public class TutorialEventSettings
{
    public string Description;
    public int Id;
    public TutorialEventType TutorialEventType;
}

[Serializable]
public class TutorialEventLanguageSettings
{
    public string En;
    public int Id;
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
            _ => throw new NotImplementedException()
        };
        return currentLanguage;
    }
}

public enum TutorialEventType
{
    OnMove = 1,
    OnPickUp,
    OnDrop,
    OnScroll,
    OnShow,
    OnTv,
    OnPhone,
    OnPresent,
    OnReturned,
    OnInstall,
    OnChangeAudio,
    OnOpera
}