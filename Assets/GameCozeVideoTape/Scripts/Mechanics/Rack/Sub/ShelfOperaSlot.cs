using UnityEngine;

public class ShelfOperaSlot : BazeSlot
{
    protected override void CheckEmptySlot(CassetteObject currentCassette)
    {
        if (!IsEmpty) { return; }

        if (_subGenreShelf.CheckCorrectSlot(currentCassette.ItemSettings, _idSlot))
        {
            _slot.SetSettings(_settings.EaseSuccess, _settings.TimeSuccess);
        }
        else
        {
            _slot.SetSettings(_settings.EaseNothing, _settings.TimeNothing);
        }

        IItemble tempItem = _playerInventory.Install(this);

        if (tempItem is CassetteObject present)
        {
            bool isNull = _slot.Install(present, out _cassetteObject);
            SubPickUp(isNull);
            _slot.gameObject.SetActive(isNull);
        }
        else
        {
            Debug.LogError("ShelfSlot_CheckEmptySlot Not Found Present ");
        }
    }
}
