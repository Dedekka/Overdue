using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Present : MonoBehaviour
{
    [SerializeField] private List<TextMeshPro> listText;
    private PresentSettings _presentSettings;

    public void SetPresentSettings(PresentSettings presentSettings)
    {
        _presentSettings = presentSettings;
        SetId(_presentSettings.NamePresent);
    }

    private void SetId(string text)
    {
        for (int i = 0; i < listText.Count; i++)
        {
            listText[i].SetText(text);
        }
    }
}
