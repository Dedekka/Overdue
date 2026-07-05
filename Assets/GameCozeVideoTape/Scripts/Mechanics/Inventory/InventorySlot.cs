using UnityEngine;

public class InventorySlot
{
    private CassetteObject _currentCassette;
    //private CassetteObject[] _cassets;
    private InventoryData[] _cassets2;

    private readonly Transform _hand;
    //private readonly Transform _startPos;
    //private readonly Transform _endPos;
    private readonly int _SlotInventoryMax;
    private int _countSlotInventory;

    public InventorySlot(SettingsPlayer settingsPlayer, Transform hand)//, Transform startPos, Transform endPos)
    {
        _SlotInventoryMax = settingsPlayer.CountSlotInventory;
        _hand = hand;
        _cassets2 = CreateInventoryData(_SlotInventoryMax);
        //_cassets = new CassetteObject[_SlotInventoryMax];
        _countSlotInventory = 0;
        //_startPos = startPos;
        //_endPos = endPos;
    }

    public bool CheckFreeSlot(CassetteObject CassetteObject, out Transform transform)
    {
        bool isSucsses = false;
        transform = _hand;
        _currentCassette = CassetteObject;
        isSucsses = _countSlotInventory < _SlotInventoryMax;
        if (isSucsses)
        {
            AddCassette(CassetteObject);
            Debug.Log($"Slot {CassetteObject.gameObject.name} Index {_countSlotInventory}");
            _countSlotInventory++;
        }
        return isSucsses;
    }

    public void Drop()
    {
        if (_currentCassette != null)
        {
            _currentCassette.Drop(_hand.right);
            _currentCassette = null;
            _countSlotInventory--;

            ChangeCurrentCassette();
        }
    }

    private void ChangeCurrentCassette()
    {
        Debug.Log($"ChangeCurrentCassette|countSlotInventory {_countSlotInventory-1}");
        if (_countSlotInventory == 0) { return; }
        _currentCassette = GetCassetteForIndex(_countSlotInventory-1);
        //_currentCassette = GetCassette()

        //Debug.Log($"_countSlotInventory {_countSlotInventory}");
        //if (_countSlotInventory <= 0)
        //{
        //    _countSlotInventory = 0;
        //    _currentCassette = null;
        //}
        //else
        //{
        //    _currentCassette = _cassets[_countSlotInventory];
        //}
    }

    private CassetteObject GetCassetteForIndex(int index)
    {
        CassetteObject tempCassetteObject = null;   
        foreach (var _cassets in _cassets2)
        {
            if (_cassets.Index == index)
            {
                if (_cassets.CassetteObject != null)
                {
                    tempCassetteObject = _cassets.CassetteObject;
                    return tempCassetteObject;
                }
                else
                {
                    //tempCassetteObject = GetCassetteForIndex(index--);
                }
            }
        }
        Debug.Log($"GetCassetteForIndex| null");
        return tempCassetteObject;
    }

    private void AddCassette(CassetteObject cassetteObject)
    {
        CassetteObject tempCassette = GetCassetteForIndex(_countSlotInventory);
        tempCassette = cassetteObject;
        //GetCassetteForIndex

        //inventoryData.CassetteObject = cassetteObject;
        //inventoryData.Index = _countSlotInventory;
    }

    private InventoryData[] CreateInventoryData(int slotInventoryMax)
    {
        InventoryData[] tempInventoryDataArray = new InventoryData[slotInventoryMax];
        for (int i = 0; i < tempInventoryDataArray.Length; i++)
        {
            tempInventoryDataArray[i].Index = i;
        }
        return tempInventoryDataArray;
    }
}

public struct InventoryData
{
    public CassetteObject CassetteObject;
    public int Index;

}