using UnityEngine;
using UnityEngine.Video;

public class TV_Text : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;

    [ContextMenu("Play")]
    public void Play()
    {
        if (player == null)
        {
            player = GetComponent<VideoPlayer>();
        }

        player.Play();
    }
}
