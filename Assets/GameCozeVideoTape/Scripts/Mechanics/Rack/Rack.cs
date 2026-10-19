using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[SelectionBase]
public abstract class Rack : MonoBehaviour
{
    public Genre Genre => _genre;
    public List<DataShelf> SubGenreShelfs => _subGenreShelfs;
    public int CountSuccessInstall => _countSuccessInstall;
    [SerializeField] protected Genre _genre;
    [SerializeField] private List<DataShelf> _subGenreShelfs;
    private SubGenreAchievement _subGenreAchievement;
    private ManagerRack _managerRack;
    private int _countSuccessInstall;
    public event Action OnChanheCountSuccessInstall;

    public Action<bool> OnInstallState;

    [Inject]
    private void Construct(ManagerRack managerRack, SubGenreAchievement subGenreAchievement)
    {
        _managerRack = managerRack;
        _subGenreAchievement = subGenreAchievement;
    }

    private void Awake()
    {
        _managerRack.AddRack(this);
        Initialization();
    }

    private void OnDisable()
    {
        _subGenreAchievement.Dispose();
    }

    public virtual bool CheckCorrectSlot(int subGenreindex, CassetteObject cassetteObject)
    {
        ItemSettings ItemSettings = cassetteObject.ItemSettings;
        bool installState = ItemSettings.IdGenre == (int)_genre && subGenreindex == ItemSettings.IdSubGenre;
        //OnChangeState(installState);
        //SubPickUp(cassetteObject, installState);
        return installState;
    }

    public virtual void Install(CassetteObject cassetteObject, bool installState)
    {
        OnChangeState(installState);
        SubPickUp(cassetteObject, installState);
    }

    protected void OnChangeState(bool installState)
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
        _subGenreAchievement.Initialization(this);
    }

    protected void SubPickUp(CassetteObject cassetteObject, bool installState)
    {
        //cassetteObject.OffInteracteble();
        if (!installState) { return; }
        cassetteObject.OnPickUp += OnPickUp;
        _countSuccessInstall++;
        OnChanheCountSuccessInstall?.Invoke();
    }

    private void OnPickUp(CassetteObject cassetteObject)
    {
        cassetteObject.OnPickUp -= OnPickUp;
        _countSuccessInstall = _countSuccessInstall > 0 ? _countSuccessInstall - 1 : 0;
        OnChanheCountSuccessInstall?.Invoke();
    }


}

[Serializable]
public class DataShelf
{
    public int SubGenreindex;
    public SubGenreShelf SubGenreShelfs;
}