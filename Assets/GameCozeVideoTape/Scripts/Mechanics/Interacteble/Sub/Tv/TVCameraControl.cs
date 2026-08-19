using Unity.Cinemachine;

public class TVCameraControl
{
    private CinemachineCamera _camera;
    private const float _OnFov = 13;
    private const float _OffFov = 60;

    public TVCameraControl(CinemachineCamera camera)
    {
        _camera = camera;
    }

    public void StartEpisode()
    {
        _camera.gameObject.SetActive(true);
        _camera.Priority = 15;
        //ChangeFov(_OnFov);
    }

    public void EndEpisode()
    {
        _camera.Priority = -1;
        _camera.gameObject.SetActive(false);
        //ChangeFov(_OffFov);
    }

    //private void ChangeFov(float endFov)
    //{
    //    _camera.Lens.FieldOfView = endFov;
    //}
}
