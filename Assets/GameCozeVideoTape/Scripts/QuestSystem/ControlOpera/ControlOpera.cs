using System.Collections.Generic;
using Zenject;

public class ControlOpera : IInitializable
{
    private DataOpera _dataOpera;
    private ManagerCassette _managerCassette;
    private List<int> _idOperaCassette;

    public ControlOpera(DataOpera dataOpera, ManagerCassette managerCassette)
    {
        _dataOpera = dataOpera;
        _managerCassette = managerCassette;
        _idOperaCassette = new List<int>();
    }

    public void Initialize()
    {
        FindOperaCassette();
        OffCassetteOpera();
    }

    private void OffCassetteOpera()
    {
        ControlActive(false);
    }

    public void OnCassetteOpera()
    {
        ControlActive(true);
    }

    private void ControlActive(bool isActive)
    {
        int id = 0;
        for (int i = 0; i < _idOperaCassette.Count; i++)
        {
            id = _idOperaCassette[i];
            if (_managerCassette.CassetsDictionary.TryGetValue(id, out CassetteObject cassette))
            {
                cassette.gameObject.SetActive(isActive);
            }
        }
    }


    private void FindOperaCassette()
    {
        List<OperaSettings> operaSettings = _dataOpera.GetOperaSettings();

        for (int i = 1; i < operaSettings.Count; i++)
        {
            _idOperaCassette.Add(operaSettings[i].Id_Cassette);
        }
    }
}