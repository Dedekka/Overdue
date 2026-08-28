using UnityEngine;

public class OperaChecker : ISloteble
{
    public int CurrentIdOpera {  get; private set; }
    private PlayerInventory _playerInventory;
    private DataOpera _dataOpera;
    private OperaSettings _operaSettings;

    public OperaChecker(PlayerInventory playerInventory, DataOpera dataOpera)
    {
        _playerInventory = playerInventory;
        _dataOpera = dataOpera;
    }

    public bool CheckEpisode(int idEpisode)
    {
        _operaSettings = null;
        _operaSettings = _dataOpera.GetOperaSettingsForIdCassette(idEpisode);
        return _operaSettings != null;
    }

    public OperaSettings GetOperaEpisode()
    {
        return _operaSettings;
    }

    public bool CheckHand(bool isVisible)
    {
        if (isVisible)
        {
            return CheckItem();
        }
        return false;
    }

    private bool CheckItem()
    {
        bool isVisible = false;
        if (_playerInventory.CheckActiveItem(this, out IItemble item))
        {
            if (item is CassetteObject cassette)
            {
                isVisible = CheckId(cassette);
            }
        }
        return isVisible;
    }

    private bool CheckId(CassetteObject cassette)
    {
        bool IsOpera = cassette.IsOpera;
        CurrentIdOpera = IsOpera ? cassette.Id : -1;
        return IsOpera;
    }
}