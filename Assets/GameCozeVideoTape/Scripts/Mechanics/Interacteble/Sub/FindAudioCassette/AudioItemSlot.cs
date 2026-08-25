using Zenject;

public class AudioItemSlot : AudioItem
{
    private AudioCassettsSystem _audioCassettsSystem;

    [Inject]
    public void Construct(AudioCassettsSystem audioCassettsSystem)
    {
        _audioCassettsSystem = audioCassettsSystem;
    }

    protected override void OnInteract()
    {
        _audioCassettsSystem.SetMusic(Id);
        //_audioRecorder.ActiveAudioSlot(Id);
        //gameObject.SetActive(false);
    }
}