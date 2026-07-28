using System;
using System.Collections.Generic;
using UnityEngine;

public class RackHolder
{
    [field: SerializeField] public SaveRack SaveRack { get; private set; }

    public List<RackData> LoadedRack;

    public event Action OnUpdateItems;
    public event Action OnSave;

    public void AddRack(Dictionary<int, RackGenre> racksDictionary)
    {
        GetCassetteItems(racksDictionary, out List<RackData> items);
        SaveRack = new SaveRack(items.ToArray());
    }

    public void SetUpdate(Dictionary<int, CassetteObject> _cassetsDictionary, Dictionary<int, RackGenre> racksDictionary)
    {
        RackGenre tempRack;
        SaveSubGange[] SubGangeData;
        for (int i = 0; i < LoadedRack.Count; i++)
        {
            if (racksDictionary.TryGetValue(LoadedRack[i].IdGange, out tempRack))
            {
                SubGangeData = LoadedRack[i].SubGangeData;
                ChangeDataShelf(tempRack.SubGenreShelfs, _cassetsDictionary, SubGangeData);
            }
        }
    }

    public void UpdateItems()
    {
        LoadedRack = SaveRack.Items;
        OnUpdateItems?.Invoke();
    }

    public void Save()
    {
        OnSave?.Invoke();
    }

    private void GetCassetteItems(Dictionary<int, RackGenre> racksDictionary, out List<RackData> rackData)
    {
        rackData = new List<RackData>();
        RackGenre tempRack;

        for (int i = 1; i < 16; i++)
        {
            if (racksDictionary.TryGetValue(i, out tempRack))
            {
                rackData.Add(new RackData()
                {
                    IdGange = i,
                    SubGangeData = GetSubGange(tempRack.SubGenreShelfs),
                });
            }
        }
    }

    private SaveSubGange[] GetSubGange(List<DataShelf> SubGenreShelfs)
    {
        SaveSubGange[] saveSubs = new SaveSubGange[SubGenreShelfs.Count];
        for (int i = 0; i < SubGenreShelfs.Count; i++)
        {
            saveSubs[i] = new SaveSubGange()
            {
                IdSubGange = SubGenreShelfs[i].SubGenreindex,
                Slots = GetSaveSlot(SubGenreShelfs[i].SubGenreindex, SubGenreShelfs[i].SubGenreShelfs.ShelfSlot)
            };
        }
        return saveSubs;
    }

    private SaveSlot[] GetSaveSlot(int idSubGange, ShelfSlot[] ShelfSlot)
    {
        SaveSlot[] saveSlot = new SaveSlot[ShelfSlot.Length];
        for (int i = 0; i < ShelfSlot.Length; i++)
        {
            saveSlot[i] = new SaveSlot()
            {
                IdSubGange = idSubGange,
                IsFree = ShelfSlot[i].TryGetIdCassette(out int idCassette),
                IdCassette = idCassette
            };
        }
        return saveSlot;
    }

    private void ChangeDataShelf(List<DataShelf> dataShelf, Dictionary<int, CassetteObject> _cassetsDictionary, SaveSubGange[] SubGangeData)
    {

        for (int i = 0; i < SubGangeData.Length; i++)
        {
            if (dataShelf[i].SubGenreindex != SubGangeData[i].IdSubGange)
            {
                Debug.LogError("ChangeDataShelf not Found Index");
                return;
            }
            ChangeShelfSlot(dataShelf[i].SubGenreShelfs.ShelfSlot, _cassetsDictionary, SubGangeData[i].Slots);

        }
    }

    private void ChangeShelfSlot(ShelfSlot[] ShelfSlot, Dictionary<int, CassetteObject> _cassetsDictionary, SaveSlot[] SubGangeData)
    {
        CassetteObject tempCassette;
        for (int i = 0; i < SubGangeData.Length; i++)
        {
            _cassetsDictionary.TryGetValue(SubGangeData[i].IdCassette, out tempCassette);
            ShelfSlot[i].Load(tempCassette);
        }
    }
}