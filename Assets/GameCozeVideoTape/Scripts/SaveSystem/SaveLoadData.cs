using System;

namespace SaveLoadSystem
{
    [Serializable]
    public class SaveLoadData
    {
        public SaveLoadData(string id, object[] data)
        {
            Id = id;
            Data = data;
        }

        /// <summary>
        /// Id of component to which SaveData belongs. 
        /// </summary>
        public string Id { get; private set; } // можем запросить Id на чтение 

        /// <summary>
        /// Saved Data.
        /// </summary>
        public object[] Data { get; private set; } // можем запросить список объектов на чтение 
    }
}