using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestPromoActiveMusic : MonoBehaviour
{
    [SerializeField] private List<AudioItemSlot> audioItems;
    [SerializeField] private GameObject _body;
    [SerializeField] private GameObject _musicTrigger;
    [SerializeField] private GameObject _presentItem;


    private void Update()
    {
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            ActiveAudioItemSlot();
        }
    }

    private void ActiveAudioItemSlot()
    {
        if (audioItems==null) { return; }

        for (int i = 0; i < audioItems.Count; i++)
        {
            audioItems[i].gameObject.SetActive(true);
        }
        _body.SetActive(true);
        _musicTrigger.SetActive(true);
        _presentItem.SetActive(false);
    }
}
