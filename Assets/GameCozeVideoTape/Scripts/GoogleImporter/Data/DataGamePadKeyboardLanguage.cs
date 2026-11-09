using System.Collections.Generic;
using UnityEngine;

public class DataGamePadKeyboardLanguage : ScriptableObject, IDatable
{
    [HideInInspector]
    public string[] GamePadKeyboardName;
    [SerializeField] private List<GamePadKeyboardLanguageSettings> itemSettings;
    private Dictionary<int, GamePadKeyboardLanguageSettings> _cassetsData;
    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        itemSettings = mainGoogleSettings.GamePadKeyboardLanguageSettings;
        SetGamePadKeyboardName();
    }

    public GamePadKeyboardLanguageSettings GetGamePadKeyboardLanguageSettings(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(itemSettings);
        }
        GamePadKeyboardLanguageSettings tempItem = _cassetsData.TryGetValue(id, out GamePadKeyboardLanguageSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<GamePadKeyboardLanguageSettings> itemSettings)
    {
        _cassetsData = new Dictionary<int, GamePadKeyboardLanguageSettings>();
        foreach (var item in itemSettings)
        {
            _cassetsData.Add(item.ID, item);
        }
    }

    private void SetGamePadKeyboardName()
    {
        GamePadKeyboardName = new string[itemSettings.Count];
        for (int i = 0; i < itemSettings.Count; i++)
        {
            GamePadKeyboardName[i] = (itemSettings[i].KEY);
        }
    }

    [ContextMenu("CheckName")]
    private void CheckName()
    {
        Debug.Log("CheckName Start");
        for (int i = 0; i < GamePadKeyboardName.Length; i++)
        {
            Debug.Log($"GamePadKeyboardName: {GamePadKeyboardName[i]}");

        }
        Debug.Log("CheckName End");
    }
}