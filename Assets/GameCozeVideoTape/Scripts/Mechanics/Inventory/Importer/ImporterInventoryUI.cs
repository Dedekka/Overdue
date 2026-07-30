using System;
using UnityEngine;
using Zenject;

public class ImporterInventoryUI : IDisposable, IInitializable
{
    private PlayerUi _playerUi;
    private InventorySlot _inventorySlot;

    public ImporterInventoryUI(InventorySlot inventorySlot, PlayerUi playerUi)
    {
        _playerUi = playerUi;
        _inventorySlot = inventorySlot;
    }

    public void Initialize()
    {
        _inventorySlot.OnChangeSlot += OnChangeSlot;
    }

    public void Dispose()
    {
        _inventorySlot.OnChangeSlot -= OnChangeSlot;
    }

    private void OnChangeSlot(CassetteObject[] Cassettes)
    {
        string newText = string.Empty;
        for (int i = 0; i < Cassettes.Length; i++)
        {
            if (Cassettes[i] != null)
            {
                newText += $"*{Cassettes[i].Description} \n";
            }
        }
        _playerUi.UpdateTextInventory(newText);
    }

    //private void OnChangeCurrentInteracteble(string description)
    //{
    //    _playerUi.UpdateTextDescription(description);
    //}

    //private void OnShowPanelUse(bool isShowPanelUse)
    //{
    //    _playerUi.ShowPanelUse(!isShowPanelUse);
    //}
}
