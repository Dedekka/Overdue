using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DataPresent", menuName = "Create/DataPresent")]
public class DataPresent : ScriptableObject
{
    [SerializeField] private List<PresentSettings> _dataPresents;
    private Dictionary<int, PresentSettings> _presentsData;

    private bool _checkDictionary => _presentsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _dataPresents = mainGoogleSettings.Presents;
    }

    public PresentSettings GetPresentSettings(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_dataPresents);
        }
        PresentSettings tempItem = _presentsData.TryGetValue(id, out PresentSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<PresentSettings> itemSettings)
    {
        _presentsData = new Dictionary<int, PresentSettings>();
        foreach (var item in itemSettings)
        {
            _presentsData.Add(item.IdPresent, item);
        }
    }
}
