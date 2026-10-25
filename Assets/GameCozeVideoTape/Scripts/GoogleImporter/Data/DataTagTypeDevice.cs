using System.Collections.Generic;
using UnityEngine;

public class DataTagTypeDevice : ScriptableObject
{
    [SerializeField] private List<TagTypeDeviceSettings> _tutorialEventSettings;
    private Dictionary<int, TagTypeDeviceSettings> _cassetsData;

    private bool _checkDictionary => _cassetsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _tutorialEventSettings = mainGoogleSettings.TagTypeDeviceSettings;
    }

    public int GetCount()
    {
        return _tutorialEventSettings.Count;
    }

    public TagTypeDeviceSettings GetTagTypeDeviceSettings(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_tutorialEventSettings);
        }
        TagTypeDeviceSettings tempItem = _cassetsData.TryGetValue(id, out TagTypeDeviceSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<TagTypeDeviceSettings> tutorialEventSettings)
    {
        _cassetsData = new Dictionary<int, TagTypeDeviceSettings>();
        foreach (var item in tutorialEventSettings)
        {
            _cassetsData.Add(item.IdTag, item);
        }
    }
}
