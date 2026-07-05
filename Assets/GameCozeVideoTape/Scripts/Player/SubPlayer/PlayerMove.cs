using UnityEngine;
using Zenject;

public class PlayerMove : IFixedTickable //ITickable,*/
{
    private Collider[] _colliders;
    private CharacterController _controller;
    private Transform _body;
    private Transform _groundPoint;
    private Vector3 _playerVelocity;
    private Vector3 _velocityGround;
    private Vector3 _moveDirection;
    private Vector3 _final;
    private LayerMask _groundLayer;
    private float _coefficientSpeedForAim;
    private float _groundPointRadius;
    private float _gravity;
    private float _speed;
    private readonly float _normalSpeed;
    private bool _isGrounded;

    public PlayerMove(SettingsPlayer settingsPlayer, CharacterController characterController, Transform groundPoint)
    {
        _normalSpeed = settingsPlayer.MovementSpeed;
        _groundPoint = groundPoint;
        _groundLayer = settingsPlayer.GroundLayer;
        _groundPointRadius = settingsPlayer.GroundPointRadius;
        _gravity = settingsPlayer.Gravity;
        _controller = characterController;
        _velocityGround = new Vector3(0, -2, 0);
        _speed = _normalSpeed;
        _body = characterController.transform;
        _colliders = new Collider[10];
        _coefficientSpeedForAim = 1;
    }

    public void ProcessMove(Vector2 pos)
    {
        _moveDirection.x = pos.x;
        _moveDirection.z = pos.y;
        _moveDirection = _body.TransformDirection(_moveDirection);
        _playerVelocity.y += _gravity * Time.deltaTime;
        _speed = _normalSpeed * _coefficientSpeedForAim;
        if ((_isGrounded && _playerVelocity.y < 0))
        {
            _playerVelocity = _velocityGround;
        }
        _final = _moveDirection * _speed + _playerVelocity;
        _controller.Move(_final * Time.deltaTime);
    }

    /// <summary>
    /// »змен€ет coefficient скорости когда игрок прицеливаетс€ 
    /// </summary>
    /// <param name="coefficientSpeed"></param>
    public void ChangeCoefficientSpeedForAim(float coefficientSpeed)
    {
        ChangeCoefficientSpeed(ref _coefficientSpeedForAim, coefficientSpeed);
    }

    public void FixedTick()
    {
        CheckGround();
    }

    private void ChangeCoefficientSpeed(ref float coefficient, float tempCoefficientSpeed)
    {
        tempCoefficientSpeed = Mathf.Abs(tempCoefficientSpeed);
        coefficient = tempCoefficientSpeed > 1 ? 1 : tempCoefficientSpeed;
    }

    private void CheckGround()
    {
        _isGrounded = Physics.OverlapSphereNonAlloc(_groundPoint.position, _groundPointRadius, _colliders, _groundLayer) > 0;
    }
}