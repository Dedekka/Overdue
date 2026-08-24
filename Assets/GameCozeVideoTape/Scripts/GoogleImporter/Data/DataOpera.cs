using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataOpera", menuName = "Create/DataOpera")]
public class DataOpera : ScriptableObject
{
    [SerializeField] private List<OperaSettings> _dataOpera;
    private Dictionary<int, OperaSettings> _presentsData;

    private bool _checkDictionary => _presentsData == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _dataOpera = mainGoogleSettings.Opera;
    }

    public int GetCountOpera()
    {
        return _dataOpera.Count;
    }

    public OperaSettings GetOperaSettings(int id)
    {
        if (_checkDictionary)
        {
            SetDictionary(_dataOpera);
        }
        OperaSettings tempItem = _presentsData.TryGetValue(id, out OperaSettings item) ? item : null;
        return tempItem;
    }

    private void SetDictionary(List<OperaSettings> itemSettings)
    {
        _presentsData = new Dictionary<int, OperaSettings>();
        foreach (var item in itemSettings)
        {
            _presentsData.Add(item.Id_Cassette, item);
        }
    }

}
