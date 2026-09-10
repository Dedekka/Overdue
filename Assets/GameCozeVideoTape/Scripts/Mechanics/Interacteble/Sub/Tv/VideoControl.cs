using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl
{
    private ControlOperaLanguage _controlOperaLanguage;
    private VideoPlayer _videoPlayer;
    public event Action OnEndEpisode;

    public VideoControl(ControlOperaLanguage controlOperaLanguage)
    {
        _controlOperaLanguage = controlOperaLanguage;
    }

    public void Initialization(VideoPlayer videoPlayer)
    {
        _videoPlayer = videoPlayer;
    }

    public void SetVideo(VideoClip video = null)
    {
        if (video == null)
        {
        _videoPlayer.clip = _controlOperaLanguage.GetSubtitles().Video;
        }
        else
        {
            _videoPlayer.clip = video;
        }
        StopVideo();
    }

    public void StopVideo()
    {
        _videoPlayer.Stop();
        ClearVideo();
    }

    public void StartEpisode()
    {
        _videoPlayer.Play();
        _videoPlayer.loopPointReached += OnEndVideo;
    }

    private void OnEndVideo(VideoPlayer source)
    {
        OnEndEpisode?.Invoke();
    }

    public void ClearVideo()
    {
        Debug.Log("ClearVideo");
        ClearRenderTexture(Color.black);
    }

    private void ClearRenderTexture(Color color)
    {
        RenderTexture renderTexture = _videoPlayer.targetTexture;

        if (renderTexture == null) return;

        RenderTexture.active = renderTexture;
        GL.Clear(true, true, color);
        _videoPlayer.targetTexture = renderTexture;
    }
}