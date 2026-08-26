using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Zenject;

public class TestLookItem : MonoBehaviour
{
    [SerializeField] private Volume _Volume;
    [SerializeField] private Transform _lookItemPos;
    [SerializeField] private GameObject _item;
    [SerializeField] private float _timeMove;
    [SerializeField] private CanvasGroup _uiPlayer;
    [SerializeField] private GameObject _lookItemCanvas;
    [SerializeField] private TestMoveItem _testMoveItem;

    private Vector3 _position;
    private Quaternion _rotation;

    private PlayerStateControl _playerStateControl;


    [Inject]
    public void Construct(PlayerStateControl playerStateControl)
    {
        _playerStateControl = playerStateControl;
    }

    private void Update()
    {
        if (Keyboard.current.digit8Key.wasPressedThisFrame)
        {
            Move();
        }

        if (Keyboard.current.digit9Key.wasPressedThisFrame)
        {
            UnMove();
        }

    }

    private void Move()
    {
        _position = _item.transform.position;
        _rotation = _item.transform.rotation;

        _item.transform.parent = _lookItemPos;
        _item.transform.DOLocalMove(Vector3.zero, _timeMove).Play();
        _item.transform.DOLocalRotate(Vector3.zero, _timeMove).Play();
        _uiPlayer.alpha = 0;
        _playerStateControl.ChangeStateControlPlayer(false);
        _Volume.enabled = true;
        _lookItemCanvas.SetActive(true);
        _testMoveItem.ActiveRotate(true);
    }

    private void UnMove()
    {
        _item.transform.parent = null;
        _item.transform.DOMove(_position, _timeMove).Play();
        _item.transform.DORotateQuaternion(_rotation, _timeMove).Play();
        _uiPlayer.alpha = 1;
        _playerStateControl.ChangeStateControlPlayer(true);
        _Volume.enabled = false;
        _lookItemCanvas.SetActive(false);
        _testMoveItem.ActiveRotate(false);
    }
}