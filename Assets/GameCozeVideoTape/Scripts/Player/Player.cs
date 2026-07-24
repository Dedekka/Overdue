using UnityEngine;
using Zenject;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    public PlayerMove PlayerMove => _playerMove;
    public PlayerLook PlayerLook => _playerLook;
    public PlayerAim PlayerAim => _playerAim;
    public CharacterController CharacterController => _characterController;

    private CharacterController _characterController;
    private PlayerMove _playerMove;
    private PlayerInventory _playerInventory;
    private PlayerLook _playerLook;
    private PlayerAim _playerAim;

    [Inject]
    public void Construct(PlayerMove playerMove, PlayerLook playerLook, PlayerAim playerAim, PlayerInventory playerInventory)//, PlayerWeapon playerWeapon, SystemBuss systemBuss, PlayerHealth playerHealth, PlayerInteracteble playerInteracteble)
    {
        _playerMove = playerMove;
        _playerLook = playerLook;
        _playerAim = playerAim;
        _playerInventory = playerInventory;
    }

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public bool CheckActiveCassette(out CassetteObject currentCassette)
    {
        return _playerInventory.CheckActiveCassette(out currentCassette );
    }

    public CassetteObject GetCassette()
    {
       return _playerInventory.Install();
    }
}