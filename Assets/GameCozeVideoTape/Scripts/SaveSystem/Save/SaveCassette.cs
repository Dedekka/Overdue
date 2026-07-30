using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace SaveLoadSystem
{
    public class SaveCassette : ISaveLoadObject
    {
        public string ComponentSaveId => "SaveCassette";

        public List<CassetteItem> Items { get; private set; } = new();
        public List<CassetteItem> HandItems { get; private set; } = new();

        public SaveCassette( CassetteItem[] initialItems, params CassetteItem[] handItems)
        {
            Items.AddRange(initialItems);
            HandItems.AddRange(handItems);
        }

        public void SetSave(CassetteItem[] initialItems, params CassetteItem[] handItems)
        {
            Items.Clear();
            HandItems.Clear();

            Items.AddRange(initialItems);
            HandItems.AddRange(handItems);
        }

        public SaveLoadData GetSaveLoadData()
        {
            CassetteItem tempCassette;
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].Id == 53)
                {
                    tempCassette = Items[i];
                    Debug.Log($"SaveCassette_Id: {tempCassette.Id},Position:{tempCassette.Position.Y} ,Rotation: {tempCassette.Rotation.X} ");
                }
            }

            return new CassetteSaveLoadData(ComponentSaveId, Items, HandItems);
        }

        public void RestoreValues(SaveLoadData loadData)
        {
            Items.Clear();
            HandItems.Clear();

            if (loadData?.Data == null || loadData.Data.Length < 2)
            {
                Debug.LogError($"Can't restore values. Length :{loadData.Data.Length}");
                return;
            }

            // [0] - (JArray) with items
            // [1] - (int) equippedItem
            // [2] - (int) equippedArmor

            var items = ((JArray)loadData.Data[0]).ToObject<List<CassetteItem>>();
            var handItems = ((JArray)loadData.Data[1]).ToObject<List<CassetteItem>>();
            Items.AddRange(items);
            HandItems.AddRange(handItems);
        }
    }

    [Serializable]
    public class CassetteItem
    {
        [field: SerializeField] public int Id { get; set; }
        [field: SerializeField] public SavePosition Position { get; set; }
        [field: SerializeField] public SaveQuaternion Rotation { get; set; }
        [field: SerializeField] public bool IsCollider { get; set; }
        [field: SerializeField] public bool IsKinematic { get; set; }
        [field: SerializeField] public bool UseGravity { get; set; }
        //[field: SerializeField] public Transform Parent { get; set; }
    }

    [Serializable]
    public struct SavePosition
    {
        public float X;
        public float Y;
        public float Z;
    }

    [Serializable]
    public struct SaveQuaternion
    {
        public float X;
        public float Y;
        public float Z;
        public float W;
    }

}