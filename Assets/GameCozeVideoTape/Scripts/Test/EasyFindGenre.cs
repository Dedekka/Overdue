using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class EasyFindGenre : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _genreDropdown;
    [SerializeField] private TMP_Dropdown _subGenreDropdown;
    [SerializeField] private Button _activeButton;
    [SerializeField] private Transform _handSlot;

    private List<TMP_Dropdown.OptionData> _optionDataGenre;
    private List<TMP_Dropdown.OptionData> _optionDataSubGenre;

    private DataGenre _dataGenre;
    private ManagerCassette _managerCassette;

    private int _idGanre;
    private int _idSubGanre;

    [Inject]
    public void Construct(ManagerCassette managerCassette, DataGenre dataGenre)
    {
        _managerCassette = managerCassette;
        _dataGenre = dataGenre;
        _optionDataGenre = new List<TMP_Dropdown.OptionData>();
        _optionDataSubGenre = new List<TMP_Dropdown.OptionData>();
    }


#if UNITY_EDITOR
    private void Start()
    {
        _activeButton.onClick.AddListener(() => FindCassets());
        SubIdGenre();
        _genreDropdown.onValueChanged.AddListener(SubIdSubGenre);
        _subGenreDropdown.gameObject.SetActive(false);


        _genreDropdown.onValueChanged.AddListener(SaveIdGanre);
        _subGenreDropdown.onValueChanged.AddListener(SaveIdSubGanre);
    }
#endif

    private void SubIdGenre()
    {
        _genreDropdown.ClearOptions();

        for (int i = 1; i < 15; i++)
        {
            GenreSettings genreSettings = _dataGenre.GetGenreSettingsForId(i);
            var m_NewData = new TMP_Dropdown.OptionData();
            m_NewData.text = genreSettings.GenreName;
            _optionDataGenre.Add(m_NewData);
        }



        //Take each entry in the message List
        foreach (TMP_Dropdown.OptionData message in _optionDataGenre)
        {
            //Add each entry to the Dropdown
            _genreDropdown.options.Add(message);
        }
    }


    private void SubIdSubGenre(int id)
    {
        _subGenreDropdown.gameObject.SetActive(true);
        _optionDataSubGenre.Clear();
        _subGenreDropdown.ClearOptions();


        GenreSettings genreSettings = _dataGenre.GetGenreSettingsForId(id + 1);
        for (int i = 0; i < genreSettings.SubGenreList.Count; i++)
        {

            var m_NewData = new TMP_Dropdown.OptionData();
            m_NewData.text = genreSettings.SubGenreList[i].SubGenreName;
            _optionDataSubGenre.Add(m_NewData);
        }


        //Take each entry in the message List
        foreach (TMP_Dropdown.OptionData message in _optionDataSubGenre)
        {
            //Add each entry to the Dropdown
            _subGenreDropdown.options.Add(message);
        }
    }

    private void SaveIdGanre(int id)
    {
        _idGanre = SaveId(id);
        Debug.Log($"SaveIdGanre:{_idGanre}");
    }

    private void SaveIdSubGanre(int id)
    {
        _idSubGanre = SaveId(id);
        Debug.Log($"SaveIdGanre:{_idSubGanre}");
    }

    private int SaveId(int id)
    {
        return id + 1;
    }

    private void FindCassets()
    {
        CheckIdCasset();
    }

    private void CheckIdCasset()
    {
        List<CassetteObject> findedCassets = null;
        findedCassets = _managerCassette.ListCassette.FindAll((x)=> x.ItemSettings.IdGenre == _idGanre && x.ItemSettings.IdSubGenre == _idSubGanre);

        for (int i = 0; i < findedCassets.Count; i++)
        {
            findedCassets[i].Rigidbody.transform.position = _handSlot.transform.position;
        }
    }
       
}
