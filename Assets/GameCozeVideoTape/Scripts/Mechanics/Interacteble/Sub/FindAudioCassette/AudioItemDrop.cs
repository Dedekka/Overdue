using Zenject;

public class AudioItemDrop : AudioItem
{
    private AudioRecorder _audioRecorder;
    private PlayerLookItem _playerLookItem;

    [Inject]
    public void Construct(AudioRecorder audioRecorder, PlayerLookItem playerLookItem)
    {
        _audioRecorder = audioRecorder;
        _playerLookItem = playerLookItem;
    }

    protected override void OnInteract()
    {
        _playerLookItem.SetItem(this);
        _playerLookItem.Move();
    }

    public void ActiveAudioSlot()
    {
        _audioRecorder.ActiveAudioSlot(Id);
        gameObject.SetActive(false);
    }
}