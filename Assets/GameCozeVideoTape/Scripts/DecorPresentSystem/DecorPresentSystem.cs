using System;
using System.Collections.Generic;
using UnityEngine;

public class DecorPresentSystem : MonoBehaviour
{
    [SerializeField] private List<DataDecorSlot> _listDataDecorSlot;
    private DataDecorSlot _currentDataDecorSlot;

    public event Action<int> OnInstall;

    private void Start()
    {
        Initialization();
    }

    private void OnDisable()
    {
        foreach (var shelf in _listDataDecorSlot)
        {
            if (shelf.DecorPresent == null) { return; }
            shelf.DecorPresent.OnInstall -= OnInstallDecor;
        }
    }

    public void ControlVisible(int id)
    {
        if (BlockActive(id)) { return; }

        FindDataDecorSlot(id);

    }

    private void Initialization()
    {
        foreach (var shelf in _listDataDecorSlot)
        {
            if (shelf.DecorPresent == null) { return; }
            shelf.DecorPresent.Initialization(shelf.IdItem);
            shelf.DecorPresent.OnInstall += OnInstallDecor;
        }
    }

    private void FindDataDecorSlot(int id)
    {
        if (id < 0)
        {
            HideDecor();
        }
        else
        {
            HideDecor();

            _currentDataDecorSlot = _listDataDecorSlot.Find((x) => x.IdItem == id);
            if (_currentDataDecorSlot == null) { return; }
            _currentDataDecorSlot.DecorPresent.OnControlVisible(true);
        }
    }

    private void HideDecor()
    {
        if (_currentDataDecorSlot != null)
        {
            _currentDataDecorSlot.DecorPresent.OnControlVisible(false);
            _currentDataDecorSlot = null;
        }
    }

    private bool BlockActive(int id)
    {
        bool isBlocked = false;

        if (_currentDataDecorSlot == null && id < 0) { isBlocked = true; }

        if (_currentDataDecorSlot != null)
        {
            if (_currentDataDecorSlot.IdItem == id) { isBlocked = true; }
        }
        return isBlocked;
    }

    private void OnInstallDecor(int idItem)
    {
        OnInstall?.Invoke(idItem);
    }

}

[Serializable]
public class DataDecorSlot
{
    public string Name;
    public DecorPresent DecorPresent;
    public int IdItem;
}