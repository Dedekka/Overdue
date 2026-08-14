using Cysharp.Threading.Tasks;
using System.Collections;
using System.Threading;
using UnityEngine;

public class PickUpItem
{
    public IItemble Item => _item;
    private IItemble _item;
    private Player _player;
    private Transform _body;
    private PlayerInventory _playerInventory;
    private Coroutine _pickUp;
    private Transform _hand;
    private float _speedBlend2;
    private readonly float _speedBlend;
    private readonly float _coeffBlend;
    private readonly float _minDistance;
    private readonly float _minRotation;
    private bool _isActive;

    public PickUpItem(PickUpSettings PickUpSettings, PlayerInventory playerInventory, Transform hand, Player player)
    {
        _speedBlend = PickUpSettings.SpeedBlend;
        _coeffBlend = PickUpSettings.CoeffBlend;
        _minDistance = PickUpSettings.MinDistance;
        _minRotation = PickUpSettings.MinRotation;
        _playerInventory = playerInventory;
        _player = player;
        _hand = hand;
    }

    public void SetBody(IItemble Item)
    {
        _item = Item;
        _body = Item._body;
    }

    public void Scroll(Transform transform)
    {
        _hand = transform;
        StopMove();
        _pickUp = _player.StartCoroutine(FlyToHand(_hand));

    }

    public void StopMove()
    {
        if (_pickUp != null)
        {
            _player.StopCoroutine(_pickUp);
        }
    }

    public bool CheckFreeSlot()
    {
        return _playerInventory.CheckFreeSlot(Item);
    }

    private IEnumerator FlyToHand(Transform temptransform)
    {
        _isActive = true;
        _speedBlend2 = _speedBlend;
        while (_isActive)
        {
            Debug.Log("PickUpItem_FlyToHand");
            yield return null;
            _speedBlend2 *= _coeffBlend;
            _body.position = Vector3.Lerp(_body.position, temptransform.position, _speedBlend2 * Time.deltaTime);
            _body.rotation = Quaternion.Lerp(_body.rotation, temptransform.rotation, _speedBlend2 * Time.deltaTime);
            _isActive = CheckEnd(temptransform);
        }
        _body.transform.SetParent(_hand);   
    }

    private bool CheckEnd(Transform temptransform)
    {
        bool isCurrentPos = _minDistance < Vector3.Distance(Item._body.position, temptransform.position);
        bool isCurrentRotation = _minRotation < Quaternion.Angle(Item._body.rotation, temptransform.rotation);
        return isCurrentPos == true || isCurrentRotation == true;
    }
}