using UnityEngine;

public class InventorySlot
{
    private InventoryData[] _cassets;
    private CassetteObject[] _activeCassets;
    private CassetteObject _currentCassette;
    private readonly Transform _hand;
    //private Vector2 _rotationOffset;
    private Vector3 _startOffsetHand;
    private Vector3 _endOffsetHand;
    private float _offsetSlotY;
    private float _offsetHandY;
    private float _forceDrop;
    private int _countSlotInventory;
    private readonly int _SlotInventoryMax;
    private int _countCassette => _countSlotInventory - 1;

    public InventorySlot(SettingsPlayer settingsPlayer, Transform hand, Transform[] _inventorySlot)
    {
        _SlotInventoryMax = settingsPlayer.CountSlotInventory;
        _hand = hand;
        _offsetSlotY = settingsPlayer.HeightSlotY;
        _offsetHandY = settingsPlayer.OffsetHandY;
        //_rotationOffset = settingsPlayer.RotationOffset;
        _forceDrop = settingsPlayer.ForceDrop;
        _activeCassets = new CassetteObject[_SlotInventoryMax];
        _cassets = CreateInventoryData(_SlotInventoryMax, _inventorySlot);
        _countSlotInventory = 0;
        _startOffsetHand = _hand.localPosition;
        _endOffsetHand = _hand.localPosition;
        _endOffsetHand.y -= _offsetHandY;
    }

    public bool CheckFreeSlot(CassetteObject CassetteObject, out Transform transform)
    {
        bool isSucsses = false;
        transform = null;
        isSucsses = _countSlotInventory < _SlotInventoryMax;
        if (isSucsses)
        {
            _countSlotInventory++;
            AddCassette(CassetteObject, ref transform);
            MoveHand();
        }
        return isSucsses;
    }

    public void Drop()
    {
        ChangeCurrentCassette();
        if (_currentCassette != null)
        {
            _currentCassette.Drop();
            _currentCassette.Rigidbody.AddForce(_hand.right * _forceDrop, ForceMode.Impulse);
            _cassets[0].CassetteObject = null;
            _activeCassets[0] = null;
            _currentCassette = null;
            MoveHand();
            NextCurrentCassette();
            _countSlotInventory--;
        }
    }

    public bool CheckActiveCassette()
    {
        ChangeCurrentCassette();
        return _currentCassette != null;
    }

    public CassetteObject Install()
    {
        ChangeCurrentCassette();
        if (_currentCassette == null) { return null; }


        CassetteObject temp = _currentCassette;
        _cassets[0].CassetteObject = null;
        _activeCassets[0] = null;
        _currentCassette = null;
        MoveHand();
        NextCurrentCassette();
        _countSlotInventory--;
        return temp;

        //Debug.Log("InventorySlot_Install");
        //Debug.Log("InventorySlot_currentCassette != Null");
        //CassetteObject _tempCurrentCassette = _currentCassette;
        //Drop();
        //_tempCurrentCassette.Scroll(pos);
    }

    public void Scroll(bool duration)
    {
        ChangeSlot(duration, 0);
    }

    private void NextCurrentCassette()
    {
        CassetteObject tempCassette = _activeCassets[_countCassette];
        if (tempCassette == null) { return; }
        tempCassette.Scroll(_cassets[0].Position);
        _cassets[0].CassetteObject = _activeCassets[_countCassette];
        _cassets[_countCassette].CassetteObject = null;
        FindCasset();
    }

    private void ChangeSlot(bool direction, int startSlot)
    {
        for (int i = startSlot; i < _cassets.Length; i++)
        {
            if (i == _countSlotInventory) { break; }
            if (_countCassette < 0) { break; }
            MoveSlot(direction, i);
        }
        FindCasset();
    }

    private void ChangeCurrentCassette()
    {
        _currentCassette = _countSlotInventory == 0 ? null : _cassets[0].CassetteObject;
    }

    private InventoryData GetCassetteForIndex(int index)
    {
        InventoryData tempCassetteObject = null;
        foreach (var _cassets in _cassets)
        {
            if (_cassets.Index == index)
            {
                tempCassetteObject = _cassets;
                break;
            }
        }
        return tempCassetteObject;
    }

    private void AddCassette(CassetteObject cassetteObject, ref Transform transform)
    {
        InventoryData tempCassette = GetCassetteForIndex(_countCassette);
        _activeCassets[_countCassette] = cassetteObject;
        cassetteObject.textMeshPro.SetText(_countCassette.ToString());
        tempCassette.CassetteObject = cassetteObject;
        tempCassette.CassetteObject.gameObject.name = $"Cassette {_countSlotInventory}";
        transform = tempCassette.Position;
    }

    private InventoryData[] CreateInventoryData(int slotInventoryMax, Transform[] _inventorySlot)
    {
        InventoryData[] tempInventoryDataArray = new InventoryData[slotInventoryMax];
        tempInventoryDataArray[0] = new InventoryData();
        tempInventoryDataArray[0].Index = 0;
        tempInventoryDataArray[0].Position = _inventorySlot[0];
        for (int i = 1; i < tempInventoryDataArray.Length; i++)
        {
            tempInventoryDataArray[i] = new InventoryData();
            tempInventoryDataArray[i].Index = i;

            Vector3 pos = _hand.position;
            pos.y += i * _offsetSlotY;
            _inventorySlot[i].position = pos;
            tempInventoryDataArray[i].Position = _inventorySlot[i];
        }
        return tempInventoryDataArray;
    }

    private void FindCasset()
    {
        for (int i = 0; i < _countSlotInventory; i++)
        {
            _activeCassets[i] = _cassets[i].CassetteObject;
            if (_activeCassets[i] != null)
            {
                _activeCassets[i].textMeshPro.SetText(i.ToString());
            }
        }
    }

    private void MoveSlot(bool direction, int index)
    {
        if (direction)
        {
            if (index == _countCassette)
            {
                RevertFirstSlot(index);
            }
            else
            {
                if (CheckDropCassette(index))
                {
                    int indexNextSlot = index + 1;
                    _activeCassets[index].Scroll(_cassets[indexNextSlot].Position);
                    _cassets[indexNextSlot].CassetteObject = _activeCassets[index];
                }
                else
                {
                    _cassets[index].CassetteObject = _activeCassets[_countCassette];
                }
            }
        }
        else
        {
            if (index == 1)
            {
                RevertFirstSlot(index);
            }
            else
            {
                if (CheckDropCassette(index))
                {
                    int indexLastSlot = index - 1 < 0 ? _countCassette : index - 1;
                    _activeCassets[index].Scroll(_cassets[indexLastSlot].Position);
                    _cassets[indexLastSlot].CassetteObject = _activeCassets[index];
                }
            }
        }
    }

    private void MoveHand()
    {
        float temp = (float)_countSlotInventory / _SlotInventoryMax;
        _hand.localPosition = Vector3.Lerp(_startOffsetHand, _endOffsetHand, temp);
    }

    private bool CheckDropCassette(int index)
    {
        return _activeCassets[index] != null;
    }

    private void RevertFirstSlot(int index)
    {
        if (CheckDropCassette(index))
        {
            _activeCassets[index].Scroll(_cassets[0].Position);
            _cassets[0].CassetteObject = _activeCassets[index];
        }
    }
}

public class InventoryData
{
    public CassetteObject CassetteObject;
    public Transform Position;
    public int Index;
    public bool IsFree => CassetteObject == null;
}