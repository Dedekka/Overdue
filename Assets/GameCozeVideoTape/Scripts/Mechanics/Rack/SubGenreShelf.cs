using UnityEngine;

public class SubGenreShelf : MonoBehaviour
{
    public BazeSlot[] ShelfSlot => _shelfSlot;
    [SerializeField] private BazeSlot[] _shelfSlot;
    private Rack _rack;
    private int _subGenreindex;

    public void Initialization(Rack rack, int subGenreindex)
    {
        _subGenreindex = subGenreindex;
        _rack = rack;
        Initialization();
    }

    public bool CheckCorrectSlot(ItemSettings itemSettings, int idSlot)
    {
        return _rack.CheckCorrectSlot(idSlot, itemSettings);
    }

    public bool CheckCorrectSlot(ItemSettings itemSettings)
    {
        return _rack.CheckCorrectSlot(_subGenreindex, itemSettings);
    }

    private void Initialization()
    {
        int idSlot = 1;
        for (int i = 0; i < _shelfSlot.Length; i++)
        {
            _shelfSlot[i].Initialization(this, idSlot);
            idSlot++;
        }
    }
}