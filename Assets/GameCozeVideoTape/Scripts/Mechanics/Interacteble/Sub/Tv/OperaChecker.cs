public class OperaChecker : ISloteble
{
    public int CurrentIdCassetteOpera { get; private set; }
    private PlayerInventory _playerInventory;
    private DataOpera _dataOpera;
    private OperaSettings _operaSettings;
    
    private ControlGenreVideo _controlGenreVideo;


    public OperaChecker(PlayerInventory playerInventory, DataOpera dataOpera, ControlOperaLanguage controlOperaLanguage, ControlGenreVideo controlGenreVideo)
    {
        _playerInventory = playerInventory;
        _dataOpera = dataOpera;
        _controlGenreVideo = controlGenreVideo;
    }

    public bool CheckEpisode(int idEpisode)
    {
        _operaSettings = null;
        _operaSettings = _dataOpera.GetOperaSettingsForIdCassette(idEpisode);

        return _operaSettings != null;
    }

    public bool CheckEpisode()
    {
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
            return CheckCassette();
        }
        return false;
    }

    public bool CheckCassette()
    {
        bool isVisible = false;
        if (_playerInventory.CheckActiveItem(this, out IItemble item))
        {
            if (item is CassetteObject cassette)
            {
                isVisible = true;
                CheckId(cassette);
            }
        }
        return isVisible;
    }

    private void CheckId(CassetteObject cassette)
    {
        bool IsOpera = cassette.IsOpera;
        CurrentIdCassetteOpera = IsOpera ? cassette.Id : -1;

        CheckEpisode(CurrentIdCassetteOpera);
        if (!IsOpera)
        {
            _controlGenreVideo.CheckGenreVideo(cassette.ItemSettings.IdGenre);
        }
        //return IsOpera;
    }
}