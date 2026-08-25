using UnityEngine;
using Zenject;

public class AudioRecorder : MonoBehaviour
{
    [SerializeField] private RecorderController _recorderController;
    private MusicControl _musicControl;

    [Inject]
    public void Construct(MusicControl musicControl)
    {
        _musicControl = musicControl;
    }
    
    private void OnEnable()
    {
        _recorderController.OnChangeState += OnChangeStatePlaying;
    }

    private void OnDisable()
    {
        _recorderController.OnChangeState -= OnChangeStatePlaying;
    }

    public void SetMusic(int idMusic)
    {
        _musicControl.SetMusic(idMusic);
    }

    private void OnChangeStatePlaying()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        Debug.Log("AudioRecorder_PlayMusic");
        _musicControl.PlayMusic();
    }
}