using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EasyFindCasset : MonoBehaviour
{
    [SerializeField] private TMP_InputField _IdCasset;
    [SerializeField] private Button _activeButton;
    [SerializeField] private Transform _handSlot;

    private ManagerCassette _managerCassette;

    [Inject]
    public void Construct(ManagerCassette managerCassette)
    {
        _managerCassette = managerCassette;
    }

#if UNITY_EDITOR
    private void Start()
    {
        _activeButton.onClick.AddListener(() => FindCassets());
    }
#endif

    private void FindCassets()
    {
        CheckIdCasset();
    }

    private void CheckIdCasset()
    {
        int count = 0;
        if (int.TryParse(_IdCasset.text, out count))
        {
            if (_managerCassette.CassetsDictionary.TryGetValue(count, out CassetteObject cassette))
            {
                cassette.Rigidbody.transform.position = _handSlot.transform.position;
            }
        }
        else
        {
            _IdCasset.text = string.Empty;
        }
    }
}