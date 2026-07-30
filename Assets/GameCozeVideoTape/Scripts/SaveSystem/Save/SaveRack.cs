using Newtonsoft.Json.Linq;
using SaveLoadSystem;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveRack : ISaveLoadObject
{
    public string ComponentSaveId => "SaveRack";

    public List<RackData> Items { get; private set; } = new();

    public SaveRack( params RackData[] rackData)
    {
        Items.AddRange(rackData);
    }

    public void SetSave(params RackData[] rackData)
    {
        Items.Clear();
        Items.AddRange(rackData);
    }

    public SaveLoadData GetSaveLoadData()
    {
        return new RackSaveLoadData(ComponentSaveId, Items);
    }

    public void RestoreValues(SaveLoadData loadData)
    {
        Items.Clear();

        if (loadData?.Data == null || loadData.Data.Length < 1)
        {
            Debug.LogError($"Can't restore values. Length :{loadData.Data.Length}");
            return;
        }

        // [0] - (JArray) with items
        // [1] - (int) equippedItem
        // [2] - (int) equippedArmor

        var items = ((JArray)loadData.Data[0]).ToObject<List<RackData>>();
        Items.AddRange(items);
    }
}

[Serializable]
public class RackData
{
    [field: SerializeField] public int IdGange { get; set; }
    [field: SerializeField] public SaveSubGange[] SubGangeData { get; set; }
}

[Serializable]
public struct SaveSubGange
{
    public int IdSubGange; 
    public SaveSlot[] Slots; 
}

[Serializable]
public struct SaveSlot
{
    public int IdSubGange;
    public int IdCassette;
    public bool IsFree;
}