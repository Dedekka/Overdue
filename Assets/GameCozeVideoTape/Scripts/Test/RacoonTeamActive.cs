using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RacoonTeamActive : MonoBehaviour
{
    [SerializeField] private List<Animator> _racoons;
    [SerializeField] private List<Transform> _startPos;
    [SerializeField] private float _distance;
    [SerializeField] private float _time;


    private void Update()
    {
        if (Keyboard.current.uKey.wasPressedThisFrame)
        {
            MoveRacoon();
            ActiveRacoon();
        }
    }

    private void ActiveRacoon()
    {
        for (int i = 0; i < _racoons.Count; i++)
        {
            _racoons[i].gameObject.SetActive(true);
            _racoons[i].Play("Scene");
            _racoons[i].transform.DOMoveZ(_distance, _time).Play();
        }
    }

    private void MoveRacoon()
    {
        for (int i = 0; i < _racoons.Count; i++)
        {
            //_racoons[i].gameObject.SetActive(false);
            //_racoons[i].transform.DOKill();
            _racoons[i].transform.position = _startPos[i].position;
            _racoons[i].transform.forward = _startPos[i].forward;
        }
    }
}
