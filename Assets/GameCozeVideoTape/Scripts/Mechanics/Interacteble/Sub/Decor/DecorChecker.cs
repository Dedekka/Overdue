using UnityEngine;
using Zenject;

public class DecorChecker : ISloteble
{
    private PlayerInventory _playerInventory;

    public DecorChecker (PlayerInventory playerInventory)
    {
        _playerInventory = playerInventory;
    }

    public bool CheckEmptyHand(bool isHandCassette, int idItem)
    {
        if (isHandCassette)
        {
            return CheckItem(idItem);
        }
        return false;
    }

    public void DestroyPresent()
    {
        IItemble tempItem = _playerInventory.Install(this);

        if (tempItem is Present present)
        {
            present.Install();
        }
        else
        {
            Debug.LogError("ShelfSlot_CheckEmptySlot Not Found Present ");
        }
    }

    private bool CheckItem(int idItem)
    {
        bool isVisible = false;
        if (_playerInventory.CheckActiveItem(this, out IItemble item))
        {
            if (item is Present present)
            {
                isVisible = CheckId(idItem, present);
            }
            else
            {
                Debug.LogError("DecorChecker_CheckEmptyHand_Not Found Present ");
            }
        }
        return isVisible;
    }

    private bool CheckId(int idItem, Present present)
    {
        return present.PresentSettings.IdPresent == idItem;
    }
}
