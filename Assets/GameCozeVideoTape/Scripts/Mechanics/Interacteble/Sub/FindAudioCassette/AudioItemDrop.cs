using UnityEngine;
using Zenject;

public class AudioItemDrop : AudioItem
{
    private AudioRecorder _audioRecorder;

    [Inject]
    public void Construct(AudioRecorder audioRecorder)
    {
        _audioRecorder = audioRecorder;
    }

    protected override void OnInteract()
    {
        //_audioRecorder.ActiveAudioSlot(Id);
        //gameObject.SetActive(false);
    }
}