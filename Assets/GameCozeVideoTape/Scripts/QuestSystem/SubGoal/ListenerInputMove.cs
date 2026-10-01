using UnityEngine;

public class ListenerInputMove 
{
    public PlayerSystemActions.PlayerActions _playerActions { get; private set; }

    public ListenerInputMove(PlayerSystemActions inputActions)
    {
        _playerActions = inputActions.Player;
    }
}