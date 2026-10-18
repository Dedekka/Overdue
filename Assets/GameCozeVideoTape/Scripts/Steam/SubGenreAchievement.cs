using System;
using System.Collections.Generic;
using UnityEngine;

public class SubGenreAchievement : IDisposable
{
    private Rack _rack;
    private ControlSubGenreAchievement _controlSubGenreAchievement;

    public SubGenreAchievement(ControlSubGenreAchievement controlSubGenreAchievement)
    {
        _controlSubGenreAchievement = controlSubGenreAchievement;
    }

    public void Dispose()
    {
        _rack.OnChanheCountSuccessInstall -= OnChanheCountSuccessInstall;
    }

    public void Initialization(Rack rack)
    {
        _rack = rack;
        _rack.OnChanheCountSuccessInstall += OnChanheCountSuccessInstall;
    }

    private void OnChanheCountSuccessInstall()
    {
        List<DataShelf> _subGenreShelfs = _rack.SubGenreShelfs;
        DataShelf dataShelf = null;

        for (int i = 0; i < _subGenreShelfs.Count; i++)
        {
            dataShelf = _subGenreShelfs[i];
            if (!dataShelf.SubGenreShelfs.gameObject.activeSelf) { continue; }
            CheckComplitedSubGenre(_rack, dataShelf);
        }
    }

    private void CheckComplitedSubGenre(Rack rack, DataShelf dataShelf)
    {
        int tempCountSlot = 0;
        if (rack is OperaRack cassette)
        {
            for (int i = 0; i < dataShelf.SubGenreShelfs.ShelfSlot.Length; i++)
            {
                if (dataShelf.SubGenreShelfs.ShelfSlot[i].IsCorrectInstall)
                {
                    tempCountSlot++;
                }
            }
            if (tempCountSlot == 1)
            {
                _controlSubGenreAchievement.SetFirstOpera();
            }

            if (tempCountSlot == 3)
            {
                _controlSubGenreAchievement.SetFullOpera();
            }
        }
        else
        {
            for (int i = 0; i < dataShelf.SubGenreShelfs.ShelfSlot.Length; i++)
            {
                if (dataShelf.SubGenreShelfs.ShelfSlot[i].IsCorrectInstall)
                {
                    tempCountSlot++;
                }
            }
            if (tempCountSlot == dataShelf.SubGenreShelfs.ShelfSlot.Length)
            {
                _controlSubGenreAchievement.SetFullSubGenre(rack.Genre, dataShelf.SubGenreindex);
            }
            Debug.Log($"Rack, Genre:{rack.Genre}, SubGenre:{dataShelf.SubGenreindex},tempCountSlot:{tempCountSlot}, NEED:{dataShelf.SubGenreShelfs.ShelfSlot.Length}");
        }
    }

    
}