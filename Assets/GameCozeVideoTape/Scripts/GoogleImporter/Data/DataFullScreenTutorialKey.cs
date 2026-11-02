using System.Collections.Generic;
using UnityEngine;

public class DataFullScreenTutorialKey : ScriptableObject, IDatable
{
    [SerializeField] private List<FullScreenTutorialKeySettings> _tutorialEventSettings;
    private Dictionary<int, FullScreenTutorialKeySettings> _cassetsData;

    private bool _checkDictionary => _cassetsData == null;
    
    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _tutorialEventSettings = mainGoogleSettings.FullScreenTutorialKeySettings;
    }

    public int GetCount()
    {
        return _tutorialEventSettings.Count;
    }

    public FullScreenTutorialKeySettings GetTutorialSettings(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_tutorialEventSettings);
        }
        FullScreenTutorialKeySettings tempItem = _cassetsData.TryGetValue(id, out FullScreenTutorialKeySettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<FullScreenTutorialKeySettings> tutorialEventSettings)
    {
        _cassetsData = new Dictionary<int, FullScreenTutorialKeySettings>();
        foreach (var item in tutorialEventSettings)
        {
            _cassetsData.Add(item.Id, item);
        }
    }
}

public interface IDatable
{
    public void Initialization(MainGoogleSettings mainGoogleSettings);
}