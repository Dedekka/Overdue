using UnityEngine;

public class EventInputSystem 
{
    private PlayerUi _playerUi;

    public EventInputSystem (PlayerUi playerUi)
    {
        _playerUi = playerUi;
    }

    public void InventoryView()
    {
        _playerUi.InventoryView();
    }
}
