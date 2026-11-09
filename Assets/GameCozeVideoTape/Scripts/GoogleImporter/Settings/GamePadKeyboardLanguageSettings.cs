using System;
using UnityEngine;

[Serializable]
public class GamePadKeyboardLanguageSettings 
{
    public string KEY;
    public int ID;
    public string En;
    public string En_Secondary;
    public string Rus;
    public string Rus_Secondary;

    public void GetLanguage(Language language, out string primaryKeyText, out string secondaryKeyText)
    {
        primaryKeyText = string.Empty;
        secondaryKeyText = string.Empty;
        switch (language)
        {
            case Language.en:
                primaryKeyText = En;
                secondaryKeyText = En_Secondary;

                break;
            case Language.ru:
                primaryKeyText = Rus;
                secondaryKeyText = Rus_Secondary;
                break;
        }
    }
}
