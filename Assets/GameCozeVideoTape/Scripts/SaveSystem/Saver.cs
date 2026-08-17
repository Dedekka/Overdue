using System;
using UnityEngine;
using Zenject;

namespace SaveLoadSystem
{
    public class Saver 
    {
        private CassetteHolder _cassetteHolder;
        private RackHolder _rackHolder;

        private SaveLoadStrategy _saveLoadSystem;
        public event Action OnSave;
        public event Action OnLoad;

        public Saver(CassetteHolder cassette, SaveLoadStrategy saveLoadSystem, RackHolder rackHolder)
        {
            _cassetteHolder = cassette;
            _rackHolder = rackHolder;
            _saveLoadSystem = saveLoadSystem;
        }

        public void Initialize()
        {
            //_saveLoadSystem.AddToSaveLoad(_cassetteHolder.SaveCassette);
            //_saveLoadSystem.AddToSaveLoad(_rackHolder.SaveRack);
        }

        public void Save()
        {
            Debug.Log("Saver _ Save");
            OnSave?.Invoke();
            _cassetteHolder.Save();
            _rackHolder.Save();
            _saveLoadSystem.SaveGame(SaveType.File);
        }

        public void Load()
        {
            OnLoad?.Invoke();
            _saveLoadSystem.LoadGame(SaveType.File);
            _cassetteHolder.UpdateItems();
            _rackHolder.UpdateItems();
        }
    }
}