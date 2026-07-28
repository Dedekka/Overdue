using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[SelectionBase]
public class TestRack : BazeInteracteble
{
    public Genre Genre => _genre;
    public List<DataShelf> SubGenreShelfs => _subGenreShelfs;
    [SerializeField] private Genre _genre;
    [SerializeField] private List<DataShelf> _subGenreShelfs;
    private ManagerRack _managerRack;

    [Inject]
    private void Construct(ManagerRack managerRack)
    {
        _managerRack = managerRack;
    }

    private void Awake()
    {
        _managerRack.AddRack(this);
    }

    private void Start()
    {
        Initialization();
    }

    public bool CheckGanre(int subGenreindex, ItemSettings itemSettings)
    {
        return itemSettings.IdGenre == (int)_genre && subGenreindex == itemSettings.IdSubGenre;
    }

    private void Initialization()
    {
        foreach (var shelf in _subGenreShelfs)
        {
            if (shelf.SubGenreShelfs == null) { return; }
            shelf.SubGenreShelfs.Initialization(this, shelf.SubGenreindex);
        }
    }
}

[Serializable]
public class DataShelf
{
    public int SubGenreindex;
    public SubGenreShelf SubGenreShelfs;
}