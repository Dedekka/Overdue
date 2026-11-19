using System;

public class CheckerTvCassette : ISloteble
{
    public int CurrentIdCassetteOpera { get; private set; }
    private PlayerInventory _playerInventory;
   
    private ControlGenreVideo _controlGenreVideo;

    public event Action OnCheckCassette;
    //OperaChecker
    public CheckerTvCassette(PlayerInventory playerInventory, ControlGenreVideo controlGenreVideo)
    {
        _playerInventory = playerInventory;
        _controlGenreVideo = controlGenreVideo;
    }

    public bool CheckHand()
    {
        return CheckCassette();
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
        _controlGenreVideo.CheckGenreVideo(cassette.ItemSettings.IdGenre);
        OnCheckCassette?.Invoke();
    }
}