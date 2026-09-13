using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RackGanre : MonoBehaviour
{
    [SerializeField] GameObject _mainGanre;
    [SerializeField] List<GameObject> _subGanreList;
    private Rack rack;
    private RackPlateControl _rackPlateControl;


    // Мы хотим брать Индексы
    // Жанра стелажа это определяет какой индекс будет стоять на шейдере главной таблички
    // и поджанров
    // с помощью номера жанра и поджанра мы определяем индекс для материала таблички
    // 

    [Inject]
    private void Construct(RackPlateControl rackPlateControl)
    {
        _rackPlateControl = rackPlateControl;
    }


    private void Awake()
    {
        rack = GetComponent<Rack>();
        SetView();
    }


    //private void Start()
    //{
    //    Debug.Log($"RackGanre, IDGanre:{(int)rack.Genre}");

    //    Debug.Log($"I Use SubGanre, Count:{rack.SubGenreShelfs.Count}");

    //    for (int i = 0; i < rack.SubGenreShelfs.Count; i++)
    //    {
    //    Debug.Log($"#{i} IDSubGanre:{rack.SubGenreShelfs[i].SubGenreindex}");
    //    }
    //}

    private void SetView()
    {
        _rackPlateControl.SetMainGanre(_mainGanre, (int)rack.Genre);
        _rackPlateControl.SetSubGanre(_subGanreList, rack.SubGenreShelfs, (int)rack.Genre);
    }

    public void SetLocalization()
    {
        rack = GetComponent<Rack>();
        SetView();
    }

}
