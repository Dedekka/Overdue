using System;

public class AudioCassetteInteract : BazeInteracteble
{
    //[SerializeField] private int AudioCassette;

    //private AudioCassettsSystem _audioCassettsSystem;

    public event Action OnInteract;
    public event Action<bool> OnEnterCursor;

    public void SetDescription(string description)
    {
        Description = description;
    }

    public override void EnterCursor(bool isVisible)
    {
        OnEnterCursor?.Invoke(isVisible);
        //_cassetteEffects.ControlSelectedOutline(isVisible);
    }

    private void Awake()
    {
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        OnInteract?.Invoke();
    }
}