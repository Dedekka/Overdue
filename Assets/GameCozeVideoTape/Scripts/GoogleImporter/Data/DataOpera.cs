using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataOpera", menuName = "Create/DataOpera")]
public class DataOpera : ScriptableObject
{
    [SerializeField] private List<OperaSettings> _listDataOpera;
    private Dictionary<int, OperaSettings> _operaDataDictionary;

    private bool _checkDictionary => _operaDataDictionary == null;

    public void Initialization(MainGoogleSettings mainGoogleSettings)
    {
        _listDataOpera = mainGoogleSettings.Opera;
    }

    public void GetOpera(Dictionary<int, CassetteObject> _cassetsDictionary)
    {
        OperaSettings operaSettings;
        for (int i = 0; i < _listDataOpera.Count; i++)
        {
            operaSettings = _listDataOpera[i];

            if (_cassetsDictionary.TryGetValue(operaSettings.Id_Cassette, out CassetteObject cassetteObject))
            {
                cassetteObject.SetOpera();
            }
            else
            {
                Debug.LogError("NOT found opera CassetteObject");
            }
        }
    }

    public OperaSettings GetOperaSettingsForIdCassette(int idCassette)
    {
        if (_checkDictionary)
        {
            SetDictionary(_listDataOpera);
        }
        OperaSettings tempItem = _operaDataDictionary.TryGetValue(idCassette, out OperaSettings item) ? item : null;
        return tempItem;
    }

    //public OperaSettings GetOperaSettingsForId(int idOpera)
    //{
    //    OperaSettings tempItem = _dataOpera.Find((x)=>x.Id == idOpera);
    //    return tempItem;
    //}

    private void SetDictionary(List<OperaSettings> itemSettings)
    {
        _operaDataDictionary = new Dictionary<int, OperaSettings>();
        foreach (var item in itemSettings)
        {
            _operaDataDictionary.Add(item.Id_Cassette, item);
        }
    }

}
