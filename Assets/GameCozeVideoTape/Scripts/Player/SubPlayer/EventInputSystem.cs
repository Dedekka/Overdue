public class EventInputSystem
{
    private PauseSystem _pause;
    private PlayerUi _playerUi;
    //private DialogInput _dialogInput;

    public EventInputSystem(PlayerUi playerUi, PauseSystem pause)//, DialogInput dialogInput)
    {
        _playerUi = playerUi;
        _pause = pause;
        //_dialogInput = dialogInput;
    }

    public void InventoryView()
    {
        _playerUi.InventoryView();
    }

    public void Pause()
    {
         _pause.Pause();
    }

    //public void ContinueDialog()
    //{
    //    _playerUi.InventoryView();
    //}
}
