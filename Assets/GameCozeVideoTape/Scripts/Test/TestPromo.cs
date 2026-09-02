using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPromo : MonoBehaviour
{
    [SerializeField] private List<AudioCassetteInteract> audioItems;
   
    private void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ChangeAudioItem(0);
        }
        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ChangeAudioItem(1);
        }
        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ChangeAudioItem(2);
        }
    }

    private void ChangeAudioItem(int index)
    {
        if (index >= audioItems.Count) { return; }
        audioItems[index].BaseInteract();
    }

}