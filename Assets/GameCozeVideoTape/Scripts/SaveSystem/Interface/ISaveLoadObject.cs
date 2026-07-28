using UnityEngine;

namespace SaveLoadSystem
{
    public interface ISaveLoadObject
    {
        /// <summary>
        /// Id to identify object.
        /// </summary>
        public string ComponentSaveId { get; } // Он предоставляет Id , чтобы в сохранениях нашли SaveLoadData с его предметами

        /// <summary>
        /// Get data to save for this object.
        /// </summary>
        /// <returns>Data to save.</returns>
        public SaveLoadData GetSaveLoadData();// Он возвращает свое текущее состояние предметов 

        /// <summary>
        /// Restore object values from saved data.
        /// </summary>
        /// <param name="loadData">Data for restoring values.</param>
        public void RestoreValues(SaveLoadData loadData);// он получает свое новое количество придметов 
    }
}