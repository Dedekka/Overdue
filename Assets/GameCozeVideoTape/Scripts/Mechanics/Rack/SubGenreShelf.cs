using UnityEngine;

public class SubGenreShelf : MonoBehaviour
{
    [SerializeField] private ShelfSlot[] _shelfSlot;
    private TestRack _rack;
    private int _subGenreindex;

    public void Initialization(TestRack rack, int subGenreindex)
    {
        _subGenreindex = subGenreindex;
        _rack = rack;
        Initialization();
    }

    public bool CheckGanre(ItemSettings itemSettings)
    {
        return _rack.CheckGanre(_subGenreindex, itemSettings);
    }

    private void Initialization()
    {
        foreach (var shelf in _shelfSlot)
        {
            if (shelf == null) { return; }
            shelf.Initialization(this);
        }
    }
}