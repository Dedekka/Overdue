using System.Collections.Generic;
using UnityEngine;

public class CassetteOpera 
{
    private DataOpera _dataOpera;
    //private int _countOpera;

    public CassetteOpera(DataOpera dataOpera)
    {
        _dataOpera = dataOpera;
    }

    public void GetOpera(Dictionary<int, CassetteObject> _cassetsDictionary)
    {
        _dataOpera.GetOpera(_cassetsDictionary);
        //OperaSettings operaSettings;
        //for (int i = 0; i < _listDataOpera.Count; i++)
        //{
        //    operaSettings = _listDataOpera[i];

        //    if (_cassetsDictionary.TryGetValue(operaSettings.Id_Cassette,out CassetteObject cassetteObject))
        //    {
        //        cassetteObject.SetOpera();
        //    }
        //    else
        //    {
        //        Debug.LogError("NOT found opera CassetteObject");
        //    }
        //}
        // С помощью словоря я должен найти кассету и отметить что она оперная в кассете 
    }

   
}