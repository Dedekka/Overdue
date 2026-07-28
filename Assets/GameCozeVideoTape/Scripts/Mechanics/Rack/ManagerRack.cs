using SaveLoadSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManagerRack : IInitializable, IDisposable
{
    private Dictionary<int, RackGenre> _racksDictionary;
    private List<TestRack> _racks;
    private RackHolder _rackHolder;
    private ManagerCassette _managerCassette;
    private int _maxRack;

    public ManagerRack(int maxRack, RackHolder rackHolder, ManagerCassette managerCassette)
    {
        _racks = new List<TestRack>();
        _managerCassette = managerCassette;
        _maxRack = maxRack;
        _rackHolder = rackHolder;
    }

    public void Dispose()
    {
        _rackHolder.OnSave -= Save;
        _rackHolder.OnUpdateItems -= UpdateItems;
    }

    public void Initialize()
    {
        _rackHolder.OnSave += Save;
        _rackHolder.OnUpdateItems += UpdateItems;
    }

   
    public void AddRack(TestRack rack)
    {
        _racks.Add(rack);

        //Debug.Log($"PRE racks: {_racks.Count}");

        CheckMaxRack();
    }

    private void UpdateRack()
    {
        //_cassetteHolder.SetUpdate(_listCassette);
        //_cassetteHolder.SetHandUpdate(_cassetsDictionary);
    }

    //private void Test()
    //{
    //    RackGenre tempRack;
    //    for (int i = 1; i < 3; i++)
    //    {
    //        Debug.Log($"Test #: {i}");
    //        if (_racksDictionary.TryGetValue(i, out tempRack))
    //        {
    //            Debug.Log($"Test: {tempRack.Id}, Name:{tempRack.NameGenre}, Count:{tempRack.SubGenreShelfs.Count}");

    //            for (int j = 0; j < tempRack.SubGenreShelfs.Count; j++)
    //            {
    //                Debug.Log($"SubGenre: {tempRack.SubGenreShelfs[j].SubGenreindex}, Count:{tempRack.SubGenreShelfs.Count}");

    //                for (int k = 0; k < tempRack.SubGenreShelfs[j].SubGenreShelfs.ShelfSlot.Length; k++)
    //                {
    //                    Debug.Log($"ShelfSlot: {k}, SubGenre: {tempRack.SubGenreShelfs[j].SubGenreindex}, Count:{tempRack.SubGenreShelfs[j].SubGenreShelfs.ShelfSlot.Length}");
    //                }

    //            }
    //        }
    //    }
    //}

    private void UpdateItems()
    {
        _rackHolder.SetUpdate(_managerCassette.CassetsDictionary,_racksDictionary);
    }

    private void Save()
    {
        _rackHolder.AddRack(_racksDictionary);
    }

    private void CheckMaxRack()
    {
        if (_racks.Count == _maxRack)
        {
            SetDictionary();
            _rackHolder.AddRack(_racksDictionary);
        }
    }

    private void SetDictionary()
    {
        _racksDictionary = new Dictionary<int, RackGenre>();
        RackGenre tempRack;
        for (int i = 0; i < _racks.Count; i++)
        {
            if (_racksDictionary.TryGetValue((int)_racks[i].Genre, out tempRack))
            {
                tempRack.SubGenreShelfs.AddRange(_racks[i].SubGenreShelfs);
            }
            else
            {
                _racksDictionary.Add((int)_racks[i].Genre, new RackGenre
                {
                    NameGenre = _racks[i].Genre.ToString(),
                    Id = (int)_racks[i].Genre,
                    SubGenreShelfs = new List<DataShelf>(_racks[i].SubGenreShelfs),
                });

            }
        }
    }
}

[Serializable]
public struct RackGenre
{
    public string NameGenre;
    public int Id;
    public List<DataShelf> SubGenreShelfs;
}