using Unity.Cinemachine;
using UnityEngine;

public class LookItemCamera 
{
    private CinemachineCamera _camera;
    private float _maxFoV;
    private float _minFoV;
    private float _tempFoV;
    private bool _isActive;

    public LookItemCamera(SettingsLookItem settingsLookItem, CinemachineCamera camera)
    {
        _camera = camera;
        _maxFoV = settingsLookItem.MaxFoVLookItem;
        _minFoV = settingsLookItem.MinFoVLookItem;
    }

    public void ActiveZoom(bool isActive)
    {
        _isActive = isActive;
    }

    public void Zoom(Vector2 vector)
    {
        if (!_isActive) { return; }

        _tempFoV = CheckFov(vector.y);
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
}