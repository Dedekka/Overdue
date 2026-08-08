using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryCassette
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

    public event Action<CassetteObject[]> OnChangeSlot;

    public InventoryCassette(SettingsPlayer settingsPlayer, Transform hand, Transform[] _inventorySlot)
    {
        _SlotInventoryMax = settingsPlayer.CountSlotInventory;
        _hand = hand;
        _offsetSlotY = settingsPlayer.HeightSlotY;
        _offsetHandY = settingsPlayer.OffsetHandY;
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

    public List<CassetteObject> GetActiveCassets()
    {
        return _activeCassets.ToList();
    }

    public bool CheckActiveCassette(out CassetteObject cassetteObject)
    {
        cassetteObject = _currentCassette;
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
    }

    public void Scroll(bool duration)
    {
        ChangeSlot(duration, 0);
    }

    public void Load()
    {
        for (int i = 0; i < _cassets.Length; i++)
        {
            if (_activeCassets[i] != null)
            {
                _activeCassets[i].Drop();
            }
            _cassets[i].CassetteObject = null;
            _activeCassets[i] = null;
        }
        _currentCassette = null;
        _countSlotInventory = 0;
        OnChangeSlot?.Invoke(_activeCassets);
    }



    private void NextCurrentCassette()
    {
        CassetteObject tempCassette = _activeCassets[_countCassette];
        if (tempCassette == null)
        {
            OnChangeSlot?.Invoke(_activeCassets);
            return;
        }
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

    private void AddCassette(CassetteObject cassetteObject, ref Transform transform)
    {
        _cassets[0].CassetteObject = cassetteObject;
        cassetteObject.Scroll(_cassets[0].Position);
        for (int i = 0; i < _countCassette; i++)
        {
            _cassets[i + 1].CassetteObject = _activeCassets[i];
            _activeCassets[i].Scroll(_cassets[i + 1].Position);

        }
        FindCasset();
    }

    private void FindCasset()
    {
        for (int i = 0; i < _countSlotInventory; i++)
        {
            _activeCassets[i] = _cassets[i].CassetteObject;
        }
        OnChangeSlot?.Invoke(_activeCassets);
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
}

public class InventoryData
{
    public CassetteObject CassetteObject;
    public Transform Position;
    public int Index;
    public bool IsFree => CassetteObject == null;
}