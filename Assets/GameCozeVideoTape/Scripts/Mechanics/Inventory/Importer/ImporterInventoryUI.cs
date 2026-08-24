using System;
using System.IO;
using Zenject;

public class ImporterInventoryUI : IDisposable, IInitializable
{
    private PlayerUi _playerUi;
    private InventoryCassette _inventorySlot;

    public ImporterInventoryUI(InventoryCassette inventorySlot, PlayerUi playerUi)
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
        string textHeader = string.Empty;
        string textPanelHand = string.Empty;
        CassetteObject cassette = Cassettes[0];
        if (cassette != null)
        {
            textHeader = $"{cassette.Description}\n\n";
            for (int i = Cassettes.Length - 1; i > 0; i--)
            {
                if (Cassettes[i] != null)
                {
                    textPanelHand += $"{Cassettes[i].Description}\n";
                }
            }
        }
        _playerUi.UpdateTextInventory(textHeader, textPanelHand);
    }
}