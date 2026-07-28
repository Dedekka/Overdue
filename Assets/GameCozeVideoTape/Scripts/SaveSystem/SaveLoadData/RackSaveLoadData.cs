using SaveLoadSystem;
using System.Collections.Generic;
using UnityEngine;

public class RackSaveLoadData : SaveLoadData
{
    public RackSaveLoadData(string id, List<RackData> data) : base(id, new object[] { data })
    {

    }
}
