using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[SelectionBase]
public abstract class Rack: MonoBehaviour
{
    public Genre Genre => _genre;
    public List<DataShelf> SubGenreShelfs => _subGenreShelfs;
    [SerializeField] protected Genre _genre;
    [SerializeField] private List<DataShelf> _subGenreShelfs;
    private ManagerRack _managerRack;

    public Action<bool> OnInstallState;

    [Inject]
    private void Construct(ManagerRack managerRack)
    {
        _managerRack = managerRack;
    }

    private void Awake()
    {
        _managerRack.AddRack(this);
    }

    private void Start()
    {
        Initialization();
    }

    public virtual bool CheckCorrectSlot(int subGenreindex, ItemSettings itemSettings)
    {
        //bool installState = itemSettings.IdGenre == (int)_genre && subGenreindex == itemSettings.IdSubGenre;
        bool installState = true;
        OnChangeState(installState);
        return installState;
    }

    protected void OnChangeState( bool installState)
    {
        OnInstallState?.Invoke(installState);
    }

    private void Initialization()
    {
        foreach (var shelf in _subGenreShelfs)
        {
            if (shelf.SubGenreShelfs == null) { return; }
            shelf.SubGenreShelfs.Initialization(this, shelf.SubGenreindex);
        }
    }
}

[Serializable]
public class DataShelf
{
    public int SubGenreindex;
    public SubGenreShelf SubGenreShelfs;
}