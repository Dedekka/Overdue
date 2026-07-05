using System.Collections;
using UnityEngine;

public class PickUpItem
{
    public CassetteObject CassetteObject => _cassette;
    private CassetteObject _cassette;
    private Transform _body;
    private PlayerInventory _playerInventory;
    private Transform _hand;
    private Coroutine _pickUp;
    private float _speedBlend2;
    private readonly float _speedBlend;
    private readonly float _coeffBlend;
    private readonly float _minDistance;
    private readonly float _minRotation;
    private bool _isActive;

    public PickUpItem(PickUpSettings PickUpSettings, PlayerInventory playerInventory, Transform hand)
    {
        _speedBlend = PickUpSettings.SpeedBlend;
        _coeffBlend = PickUpSettings.CoeffBlend;
        _minDistance = PickUpSettings.MinDistance;
        _minRotation = PickUpSettings.MinRotation;
        _playerInventory = playerInventory;
        _hand = hand;
    }

    public void SetBody(CassetteObject transform, Rigidbody rigidbody)
    {
        _cassette = transform;
        _body = _cassette.transform;
    }

    public bool PickUp()
    {
        bool isSucsses = CheckFreeSlot();
        if (isSucsses)
        {
            _pickUp = _cassette.StartCoroutine(FlyToHand(_hand));
        }
        return isSucsses;
    }

    public void Drop()
    {
        _cassette.StopCoroutine(_pickUp);
    }

    private bool CheckFreeSlot()
    {
        return _playerInventory.CheckFreeSlot(CassetteObject, out _hand);
    }

    private IEnumerator FlyToHand(Transform temptransform)
    {
        _isActive = true;
        _speedBlend2 = _speedBlend;
        while (_isActive)
        {
            yield return null;
            _speedBlend2 *= _coeffBlend;
            _body.position = Vector3.Lerp(_body.position, temptransform.position, _speedBlend2 * Time.deltaTime);
            _body.rotation = Quaternion.Lerp(_body.rotation, temptransform.rotation, _speedBlend2 * Time.deltaTime);
            _isActive = CheckEnd(temptransform);
        }
        _body.SetParent(_hand);
    }

    private bool CheckEnd(Transform temptransform)
    {
        bool isCurrentPos = _minDistance < Vector3.Distance(_body.position, temptransform.position);
        bool isCurrentRotation = _minRotation < Quaternion.Angle(_body.rotation, temptransform.rotation);
        return isCurrentPos == true || isCurrentRotation == true;
    }
}