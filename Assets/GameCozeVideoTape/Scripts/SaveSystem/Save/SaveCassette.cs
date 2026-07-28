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

        public SaveLoadData GetSaveLoadData()
        {
            // Ќужно сюда передать и сохранить кассеты из руки 
            return new CassetteSaveLoadData(ComponentSaveId, Items, HandItems);
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

            var items = ((JArray)loadData.Data[0]).ToObject<List<CassetteItem>>();
            Items.AddRange(items);
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