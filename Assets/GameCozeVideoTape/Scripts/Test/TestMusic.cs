using UnityEngine;
using Zenject;

public class TestMusic : BazeInteracteble
{
    [SerializeField] private int _idMusic;
    [SerializeField] private AudioRecorder _audioRecorder;

    private void Awake()
    {
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        _audioRecorder.SetMusic(_idMusic);
    }
}