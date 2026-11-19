using System;
using UnityEngine;
using UnityEngine.Video;

public class VideoControl
{
    private VideoPlayer _videoPlayer;
    public event Action OnEndEpisode;

    public void Initialization(VideoPlayer videoPlayer)
    {
        _videoPlayer = videoPlayer;
    }

    public void SetVideo(VideoClip video)
    {
        _videoPlayer.clip = video;
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
        //Debug.Log("ClearVideo");
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