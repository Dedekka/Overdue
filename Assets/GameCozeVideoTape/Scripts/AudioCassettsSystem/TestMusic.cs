using UnityEngine;
using Zenject;

public class TestMusic : BazeInteracteble
{
    [SerializeField] private int _idMusic;
    
    private AudioCassettsSystem _audioCassettsSystem;

    [Inject]
    public void Construct(AudioCassettsSystem audioCassettsSystem)
    {
        _audioCassettsSystem = audioCassettsSystem;
    }

    private void Awake()
    {
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        _audioCassettsSystem.SetMusic(_idMusic);
    }
}