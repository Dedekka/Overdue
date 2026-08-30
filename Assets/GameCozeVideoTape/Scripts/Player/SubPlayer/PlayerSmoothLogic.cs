using UnityEngine;
using Zenject;

public class PlayerSmoothLogic : ILateTickable
{
    private Transform _playerPos;
    private Transform _bodyLogic;
    private Vector3 _tempPos;
    private float _smoothForce;

    public PlayerSmoothLogic (SettingsPlayer settingsPlayer, Player player,  Transform bodyLogic)
    {
        _playerPos = player.transform;
        _smoothForce = settingsPlayer.SmoothForceLogic;
        _bodyLogic = bodyLogic;
        _tempPos = _bodyLogic.position;
    }

    public void LateTick()
    {
        Debug.Log($"PlayerTransform:{_playerPos.position}");
        _tempPos = Vector3.Lerp(_tempPos, _playerPos.position, _smoothForce * Time.deltaTime);
        _tempPos.Set(_bodyLogic.position.x, _tempPos.y, _bodyLogic.position.z);
        Debug.Log($"SmoothTransform:{_tempPos}");
        _bodyLogic.position = _tempPos;
    }
}