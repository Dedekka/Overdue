using Zenject;

public class ActivatorGamePadKeyboard : IInitializable
{
    private GamePadKeyboard _gamePadKeyboard;
    public ActivatorGamePadKeyboard(GamePadKeyboard gamePadKeyboard)
    {
        _gamePadKeyboard = gamePadKeyboard;
    }


    public void Initialize()
    {
        _gamePadKeyboard.OnAwake();
        _gamePadKeyboard.OnStart();
    }

}
