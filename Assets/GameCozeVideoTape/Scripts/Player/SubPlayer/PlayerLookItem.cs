using UnityEngine;

public class PlayerLookItem
{
    private LookItemMove _lookItemMove;
    private LookItemRotate _lookItemRotate;

    private GameObject _currentItem;


    public void SetItem(GameObject currentItem)
    {
        _currentItem = currentItem;
    }

    public void Move()
    {

    }
}