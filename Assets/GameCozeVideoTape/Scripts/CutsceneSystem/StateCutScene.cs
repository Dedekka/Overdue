using System;

public abstract class StateCutScene
{
    public readonly int IDCutscene;
    protected readonly PlayerStateControl _playerStateControl;
    protected readonly PlayerUi _playerUi;

    public StateCutScene(int idCutscene, PlayerStateControl playerStateControl, PlayerUi playerUi)
    {
        IDCutscene = idCutscene;
        _playerStateControl = playerStateControl;
        _playerUi = playerUi;
    }

    public abstract void StartCutscene();

    public abstract void EndCutscene();
    
}
