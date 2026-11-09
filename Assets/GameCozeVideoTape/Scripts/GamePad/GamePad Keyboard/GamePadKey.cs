using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePadKey : MonoBehaviour
{
    public Button Button;
    public TextMeshProUGUI PrimaryKeyText; // Text for the primary character (e.g., lowercase)
    public TextMeshProUGUI SecondaryKeyText;
    public string PrimaryKey;
    public string SecondaryKey;

    public int Id;

    public void Initialization()
    {
        Button = GetComponent<Button>();
        TextMeshProUGUI[] texts = GetComponentsInChildren<TextMeshProUGUI>();
        SetTextMeshPro(texts);
    }

    public void SetChar(string primaryKey, string secondaryKey)
    {
        PrimaryKey = primaryKey;
        SecondaryKey = secondaryKey;
        PrimaryKeyText.SetText(primaryKey);
        SecondaryKeyText.SetText(secondaryKey);
    }

    private void SetTextMeshPro(TextMeshProUGUI[] texts)
    {
        if (texts.Length>=2)
        {
            PrimaryKeyText = texts[0];
            SecondaryKeyText = texts[1];
        }
        else
        {
            PrimaryKeyText = texts[0];
        }
    }
}