using UnityEngine;

public class InventorySlot
{
    private InventoryData[] _cassets2;
    private CassetteObject _currentCassette;
    private Vector2 _rotationOffset;
    private Vector3 _startOffsetHand;
    private Vector3 _endOffsetHand;
    private readonly Transform _hand;
    private readonly int _SlotInventoryMax;
    private int _countSlotInventory;
    private float _offsetSlotY;
    private float _offsetHandY;
    private float _forceDrop;

    public InventorySlot(SettingsPlayer settingsPlayer, Transform hand)//, Transform startPos, Transform endPos)
    {
        _SlotInventoryMax = settingsPlayer.CountSlotInventory;
        _hand = hand;
        _offsetSlotY = settingsPlayer.OffsetSlotY;
        _offsetHandY = settingsPlayer.OffsetHandY;
        _rotationOffset = settingsPlayer.RotationOffset;
        _forceDrop = settingsPlayer.ForceDrop;
        _cassets2 = CreateInventoryData(_SlotInventoryMax);
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
            _currentCassette = CassetteObject;
            AddCassette(CassetteObject, ref transform);
            Debug.Log($"Slot {CassetteObject.gameObject.name} Index {_countSlotInventory}");
            _countSlotInventory++;
            MoveHand();
        }
        return isSucsses;
    }

    public void Drop()
    {
        if (_currentCassette != null)
        {
            _currentCassette.Rigidbody.isKinematic = false;
            _currentCassette.Rigidbody.AddForce(_hand.right * _forceDrop, ForceMode.Impulse);
            _currentCassette.Drop();
            _currentCassette = null;
            _countSlotInventory--;
            MoveHand();
            ChangeCurrentCassette();
        }
    }

    private void ChangeCurrentCassette()
    {
        if (_countSlotInventory == 0) { return; }
        InventoryData temp = GetCassetteForIndex(_countSlotInventory - 1);
        _currentCassette = temp.CassetteObject;
    }

    private InventoryData GetCassetteForIndex(int index)
    {
        InventoryData tempCassetteObject = null;
        foreach (var _cassets in _cassets2)
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
        InventoryData tempCassette = GetCassetteForIndex(_countSlotInventory);
        tempCassette.CassetteObject = cassetteObject;
        transform = tempCassette.Position;
        float tempBlend = Random.Range(0, 1f);
        transform.localRotation = Quaternion.identity;
        transform.localRotation = Quaternion.AngleAxis(Random.Range(_rotationOffset.x, _rotationOffset.y), Vector3.up);
    }

    private InventoryData[] CreateInventoryData(int slotInventoryMax)
    {
        InventoryData[] tempInventoryDataArray = new InventoryData[slotInventoryMax];
        var TempSlot = new GameObject("Slot");
        for (int i = 0; i < tempInventoryDataArray.Length; i++)
        {
            tempInventoryDataArray[i] = new InventoryData();
            tempInventoryDataArray[i].Index = i;

            Vector3 pos = _hand.position;
            pos.y += i * _offsetSlotY;
            tempInventoryDataArray[i].Position = Transform.Instantiate(TempSlot.transform, pos, _hand.rotation, _hand);
        }
        return tempInventoryDataArray;
    }

    private void MoveHand()
    {
        float temp = (float)_countSlotInventory / _SlotInventoryMax;
        Debug.Log($"MoveHand {temp}");
        _hand.localPosition = Vector3.Lerp(_startOffsetHand, _endOffsetHand, temp);
    }
}

public class InventoryData
{
    public Transform Position;
    public CassetteObject CassetteObject;
    public int Index;
}