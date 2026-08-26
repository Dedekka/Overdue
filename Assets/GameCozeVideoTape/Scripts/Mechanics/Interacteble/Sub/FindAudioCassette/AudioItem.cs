using UnityEngine;
using Zenject;

[SelectionBase]
public abstract class AudioItem : MonoBehaviour
{
    public GameObject Body => _body;
    public int Id => _id;
    public MusicCassetteSettings MusicCassetteSettings => _musicCassetteSettings;
    [SerializeField] private int _id;
    [SerializeField] private AudioCassetteInteract _music;
    private ManagerAudioItem _managerAudioItem;
    private MusicCassetteSettings _musicCassetteSettings;
    private GameObject _body;

    [Inject]
    public void Construct(ManagerAudioItem ManagerAudioItem)
    {
        _managerAudioItem = ManagerAudioItem;
    }

    private void OnEnable()
    {
        _music.OnInteract += OnInteract;
    }

    private void OnDisable()
    {
        _music.OnInteract -= OnInteract;
    }

    private void Awake()
    {
        _body = transform.GetChild(0).gameObject;
        _managerAudioItem.AddAudioItem(this);
        Debug.Log($"_gameObject: {_body.name}");
    }

    private void Start()
    {
        Initialization();
    }

    protected abstract void OnInteract();

    protected virtual void Initialization()
    {
        _music.SetDescription(MusicCassetteSettings.MusicName);
    }

    public void SetSettings(MusicCassetteSettings musicCassetteSettings)
    {
        _musicCassetteSettings = musicCassetteSettings;
    }
}