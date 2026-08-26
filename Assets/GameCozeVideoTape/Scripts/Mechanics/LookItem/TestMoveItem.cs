using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestMoveItem : MonoBehaviour
{
    [SerializeField] private GameObject _slotLookItem;
    [SerializeField] private CinemachineCamera _camera;
    [SerializeField] private float _coefficientLerp;
    private bool _isActive;

    private float _maxFoV;
    private float _minFoV;
    private float _lerpFoV;
    private float _tempFoV;
    //private float _coefficientLerp;

    private float _sensitivityY;
    private float _sensitivityX;
    private float _sensitivity;
    private float _xRotation;
    private float _yRotation;

    private void Awake()
    {
        _maxFoV = 60f;
        _minFoV = 35f;
        //_coefficientLerp = 50f;
        _lerpFoV = _maxFoV;
        _tempFoV = _maxFoV;


        _sensitivityY = 1f;
        _sensitivityX = 1f;
        _sensitivity = 0.1f;
        _xRotation = 0;
        _yRotation = 0;
    }

    private void Update()
    {
        if (Keyboard.current.digit7Key.wasPressedThisFrame)
        {
            ResetPos();
        }
    }

    public void ActiveRotate(bool isActive)
    {
        _isActive = isActive;
    }

    public void ProcessRotate(Vector2 rotate)
    {
        if (!_isActive) { return; }

        float mouseX = rotate.x;
        float mouseY = rotate.y;

        mouseX *= _sensitivity;
        mouseY *= _sensitivity;
        _xRotation -= mouseY * _sensitivityY;
        _yRotation -= mouseX * _sensitivityX;
        _slotLookItem.transform.localRotation = Quaternion.Euler(_xRotation, _yRotation, 0);
    }

    public void Zoom(Vector2 vector)
    {
        if (!_isActive) { return; }

        _tempFoV = CheckFov(vector.y);

        //_lerpFoV = Mathf.Lerp(_lerpFoV, _tempFoV, _coefficientLerp);

        _camera.Lens.FieldOfView = _tempFoV;
    }

    private float CheckFov(float Fov)
    {
        float tempFov = _camera.Lens.FieldOfView;

        tempFov += Fov;

        if (tempFov > _maxFoV)
        {
            tempFov = _maxFoV;
        }

        if (tempFov < _minFoV)
        {
            tempFov = _minFoV;
        }
        return tempFov;
    }

    private void ResetPos()
    {
        ActiveRotate(false);
        _xRotation = 0;
        _yRotation = 0;
        _slotLookItem.transform.DOLocalRotate(Vector3.zero, 1f)
            .OnComplete(() => ActiveRotate(true))
            .Play();
    }
}