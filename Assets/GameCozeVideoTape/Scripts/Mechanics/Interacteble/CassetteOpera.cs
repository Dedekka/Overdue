using System.Collections.Generic;
using UnityEngine;

public class CassetteOpera 
{
    private DataOpera _dataOpera;
    private int _countOpera;

    public CassetteOpera(DataOpera dataOpera)
    {
        _dataOpera = dataOpera;
    }

    public void GetOpera(Dictionary<int, CassetteObject> _cassetsDictionary)
    {
        GetOpera();
        OperaSettings operaSettings;
        for (int i = 1; i < _countOpera; i++)
        {
            operaSettings = _dataOpera.GetOperaSettings(i);

            if (_cassetsDictionary.TryGetValue(operaSettings.Id_Cassette,out CassetteObject cassetteObject))
            {
                cassetteObject.SetOpera();
            }
            else
            {
                Debug.LogError("NOT found opera CassetteObject");
            }
        }
       // С помощью словоря я должен найти кассету и отметить что она оперная в кассете 
    }

    private void GetOpera()
    {
        _countOpera = _dataOpera.GetCountOpera()+1;
        //с помощью данных об операх я дожжен получить все индексы кассет что содержат оперу
        //и отметить на них что они считаются оперными 
    }
}