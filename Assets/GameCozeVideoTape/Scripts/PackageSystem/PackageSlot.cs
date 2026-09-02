using UnityEngine;
using Zenject;

public class PackageSlot : MonoBehaviour
{
    private Present _currentPresent;
    private Collider _collider;
    private Player _player;

    private bool _isFree => _currentPresent == null;

    [Inject]
    private void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }

    //private void Start() Only horizontal Slot
    //{
    //    Physics.IgnoreCollision(_collider, _player.CharacterController);
    //}

    public bool CheckSlot()
    {
        Debug.Log($"PackageSlot, _isFree:{_isFree}, Present:{_currentPresent}");
        // Проверяем занят ли этот слот подарком
        return _isFree;
    }

    public void SetSlot(Present currentPresent)
    {
        currentPresent.transform.position = transform.position;
        currentPresent.transform.rotation = transform.rotation;

        currentPresent.transform.SetParent(transform);

        _currentPresent = currentPresent;
        SubPickUp();
        // Устанавливаем наш подарок
        // 
    }

    private void SubPickUp()
    {
        _currentPresent.OnPickUp += OnPickUp;
    }

    private void OnPickUp(Present tempPresent)
    {
        tempPresent.OnPickUp -= OnPickUp;
        _currentPresent = null;
    }
}