using TMPro;
using UnityEngine;

public class CounterSlotCassetteUi 
{
    private TextMeshProUGUI _scoreText;

    public CounterSlotCassetteUi(TextMeshProUGUI scoreText)
    {
        _scoreText = scoreText;
    }

    public void UpdateTextCounter(string text)
    {
        if (_scoreText == null) return;
        if (_scoreText.text == text) return;
        _scoreText.text = text;
    }
}