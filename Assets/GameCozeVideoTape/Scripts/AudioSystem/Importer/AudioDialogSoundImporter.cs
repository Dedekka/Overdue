using System;
using Zenject;

public class AudioDialogSoundImporter : IDisposable, IInitializable
{
    private DialogSound _dialogSound;
    private TvGanreSound _tvGanreSound;
    private AudioManager _audioManager;

    public AudioDialogSoundImporter(DialogSound dialogSystem, AudioManager viewDialog, TvGanreSound tvGanreSound)
    {
        _dialogSound = dialogSystem;
        _audioManager = viewDialog;
        _tvGanreSound = tvGanreSound;
    }

    public void Dispose()
    {
        _dialogSound.OnChangeVoice -= OnChangeVoice;
        _dialogSound.OnPlayVoice -= OnPlayVoice;
        _dialogSound.OnStopPlayVoice -= OnStopPlayVoice;

        _tvGanreSound.OnChangeTvGanre -= OnChangeTvGanre;
        _tvGanreSound.OnPlayTvGanre -= OnPlayTvGanre;
        _tvGanreSound.OnStopPlayTvGanre -= OnStopPlayTvGanre;
    }

    public void Initialize()
    {
        _dialogSound.OnChangeVoice += OnChangeVoice;
        _dialogSound.OnPlayVoice += OnPlayVoice;
        _dialogSound.OnStopPlayVoice += OnStopPlayVoice;

        _tvGanreSound.OnChangeTvGanre += OnChangeTvGanre;
        _tvGanreSound.OnPlayTvGanre += OnPlayTvGanre;
        _tvGanreSound.OnStopPlayTvGanre += OnStopPlayTvGanre; 
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

    private void OnStopPlayTvGanre()
    {
        _audioManager.StopTvGanre();
    }

    private void OnPlayTvGanre()
    {
        _audioManager.PlayTvGanre();
    }

    private void OnChangeTvGanre(FMODUnity.EventReference eventReference)
    {
        _audioManager.SetTvGanre(eventReference);
    }
}
