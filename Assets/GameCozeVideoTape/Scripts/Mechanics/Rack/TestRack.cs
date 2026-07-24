using System;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class TestRack : BazeInteracteble
{
    [SerializeField] private Genre _genre;
    [SerializeField] private List<DataShelf> _subGenreShelfs;

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