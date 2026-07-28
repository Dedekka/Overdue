using System.Collections.Generic;
using UnityEngine;
//using SaveLoadSystem.Example;

namespace SaveLoadSystem
{
    /// <summary>
    /// Custom save load data for inventory. Appends with equipped item and equipped tool.
    /// </summary>
    public class CassetteSaveLoadData : SaveLoadData
    {
        public List<CassetteItem> HandCassetteItem{ get; private set; }
        public CassetteSaveLoadData(string id, List<CassetteItem> data, List<CassetteItem> handCassetteItem) : base(id, new object[] { data, handCassetteItem })
        {
            HandCassetteItem = handCassetteItem;
        }
    }
}