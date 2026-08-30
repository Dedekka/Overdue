using UnityEngine;

public class LookItemCamera
{
    private PlayerAim _playerAim;
    private float _maxFoV;
    private float _minFoV;
    private float _tempFoV;
    private bool _isActive;

    public LookItemCamera(SettingsLookItem settingsLookItem, PlayerAim playerAim)
    {
        _playerAim = playerAim;
        _maxFoV = settingsLookItem.MaxFoVLookItem;
        _minFoV = settingsLookItem.MinFoVLookItem;
    }

    public void ActiveZoom(bool isActive)
    {
        if (_isActive == isActive) { return; }
        _isActive = isActive;

        if (!isActive)
        {
            _playerAim.ChangeActive(true);
            _playerAim.ProcessAim(false);
        }
    }

    public void Zoom(Vector2 vector)
    {
        if (!_isActive) { return; }

        _tempFoV = CheckFov(vector.y);
        _playerAim.Zoom(_tempFoV);
    }

    private float CheckFov(float Fov)
    {
        float tempFov = _playerAim.GetFov();
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