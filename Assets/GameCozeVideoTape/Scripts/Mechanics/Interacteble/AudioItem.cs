using UnityEngine;
using Zenject;

[SelectionBase]
public class AudioItem : MonoBehaviour
{
    public GameObject Body => _body;
    public int Id => _id;
    [SerializeField] private int _id;
    private ManagerAudioItem _managerAudioItem;
    private GameObject _body;

    [Inject]
    public void Construct(ManagerAudioItem ManagerAudioItem)
    {
        _managerAudioItem = ManagerAudioItem;
    }

    private void Awake()
    {
        _body = transform.GetChild(0).gameObject;
        _managerAudioItem.AddAudioItem(this);
        Debug.Log($"_gameObject: {_body.name}");
    }
}
//AudioItem