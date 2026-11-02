using UnityEngine;
using Zenject;

[SelectionBase]
public abstract class AudioItem : MonoBehaviour
{
    public GameObject Body => _body;
    public int Id => _id;
    public string Description => _music.Description;
    public MusicCassetteSettings MusicCassetteSettings => _musicCassetteSettings;
    [SerializeField] private int _id;
    [SerializeField] private AudioCassetteInteract _music;
    private ManagerAudioItem _managerAudioItem;
    private MusicCassetteSettings _musicCassetteSettings;
    private MusicLanguage _dataMusicLanguage;
    private SelectedItemEffect _selectedItemEffect;
    private GameObject _body;

    [Inject]
    public void Construct(ManagerAudioItem ManagerAudioItem, SelectedItemEffect selectedItemEffect)
    {
        _managerAudioItem = ManagerAudioItem;
        _selectedItemEffect = selectedItemEffect;
    }

    private void OnEnable()
    {
        _music.OnInteract += OnInteract;
        _music.OnEnterCursor += OnEnterCursor;
    }

    private void OnDisable()
    {
        _music.OnEnterCursor -= OnEnterCursor;
        _music.OnInteract -= OnInteract;
    }

    private void Awake()
    {
        _body = transform.GetChild(0).gameObject;
        _managerAudioItem.AddAudioItem(this);
        _selectedItemEffect.Initialization(GetComponentInChildren<MeshRenderer>());
        Initialization();
    }

    protected virtual void OnInteract()
    {
        _selectedItemEffect.ClearEffects();
    }

    protected virtual void Initialization() { }
    private void OnEnterCursor(bool isVisible)
    {
        _selectedItemEffect.ControlSelectedOutline(isVisible);
    }

    public void SetSettings(MusicCassetteSettings musicCassetteSettings)
    {
        _musicCassetteSettings = musicCassetteSettings;
        _music.SetDescription(MusicCassetteSettings.MusicName);
        //Debug.Log($"MusicCassetteSettings, MusicName {MusicCassetteSettings.MusicName}, Id:{MusicCassetteSettings.Id}");
    }

    public void SetLanguage(string Description)
    {
        _music.SetDescription(Description);
        //Debug.Log($"MusicCassetteSettings, MusicName {MusicCassetteSettings.MusicName}, Id:{MusicCassetteSettings.Id}");
    }
}