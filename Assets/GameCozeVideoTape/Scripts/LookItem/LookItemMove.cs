using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Zenject;

public class LookItemMove 
{
    private Transform _lookItemPos;
    //private Vector3 _position;
    //private Quaternion _rotation;
    private float _timeMove;

    public LookItemMove(SettingsLookItem settingsLookItem, Transform lookItemPos)
    {
        _timeMove = settingsLookItem.TimeMove;
        _lookItemPos = lookItemPos;
    }

    public void Move(AudioItemDrop gameObject)
    {
        //_position = gameObject.transform.position;
        //_rotation = gameObject.transform.rotation;

        gameObject.transform.parent = _lookItemPos;
        gameObject.transform.DOLocalMove(Vector3.zero, _timeMove).Play();
        gameObject.transform.DOLocalRotate(Vector3.zero, _timeMove).Play();
    }

    //private void UnMove()
    //{
    //    _item.transform.parent = null;
    //    _item.transform.DOMove(_position, _timeMove).Play();
    //    _item.transform.DORotateQuaternion(_rotation, _timeMove).Play();
    //    _uiPlayer.alpha = 1;
    //    _playerStateControl.ChangeStateControlPlayer(true);
    //    _Volume.enabled = false;
    //    _lookItemCanvas.SetActive(false);
    //    _testMoveItem.ActiveRotate(false);
    //}
}
