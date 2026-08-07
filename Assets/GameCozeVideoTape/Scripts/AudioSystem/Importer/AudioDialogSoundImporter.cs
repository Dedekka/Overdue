using System;
using Zenject;

public class AudioDialogSoundImporter : IDisposable, IInitializable
{
    private DialogSound _dialogSound;
    private AudioManager _audioManager;

    public AudioDialogSoundImporter(DialogSound dialogSystem, AudioManager viewDialog)
    {
        _dialogSound = dialogSystem;
        _audioManager = viewDialog;
    }

    public void Dispose()
    {
        _dialogSound.OnChangeVoice -= OnChangeVoice;
        _dialogSound.OnPlayVoice -= OnPlayVoice;
        _dialogSound.OnStopPlayVoice -= OnStopPlayVoice;
    }

    public void Initialize()
    {
        _dialogSound.OnChangeVoice += OnChangeVoice;
        _dialogSound.OnPlayVoice += OnPlayVoice;
        _dialogSound.OnStopPlayVoice += OnStopPlayVoice; 
    }

    private void OnStopPlayVoice()
    {
        _audioManager.StopVoice();
    }

    private void OnPlayVoice()
    {
        _audioManager.PlayVoice();
    }

    private void OnChangeVoice(FMODUnity.EventReference eventReference)
    {
        _audioManager.SetVoice(eventReference);
    }
}
