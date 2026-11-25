using System;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Video;

public class FullScreenTutorialUi : MonoBehaviour
{
    [SerializeField] private LocalizeStringEvent _headerTutorial;
    [SerializeField] private LocalizeStringEvent _tutorialBodyText;
    private VideoPlayer _videoPlayer;
    private Transform _panel;
    private const string _table = "FullScreenTutorialPanel";

    private void Awake()
    {
        _videoPlayer = GetComponentInChildren<VideoPlayer>(true);
        _panel = transform.GetChild(0);
        _headerTutorial.SetTable(_table);
        _tutorialBodyText.SetTable(_table);
    }

    public void SetPanel(string Header, string Body,VideoClip video)
    {
        _headerTutorial.SetEntry(Header);
        _tutorialBodyText.SetEntry(Body);
        _videoPlayer.clip = video;
        _videoPlayer.Play();
    } 

    public void ControlActive(bool active)
    {
        _panel.gameObject.SetActive(active);
    }
}