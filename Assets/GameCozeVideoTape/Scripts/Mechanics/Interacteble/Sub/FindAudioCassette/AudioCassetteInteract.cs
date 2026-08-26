using System;

public class AudioCassetteInteract : BazeInteracteble
{
    //[SerializeField] private int AudioCassette;

    //private AudioCassettsSystem _audioCassettsSystem;

    public event Action OnInteract;

    public void SetDescription(string description)
    {
        Description = description;
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