using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

public class ContentSlot : BazeInteracteble
{
    private Player _player;
    private Ease _ease;
    private float _time;
    private MeshRenderer _meshRenderer;

    public event Action<CassetteObject> OnInteract;
    public event Action<bool> OnEnterCursor;

    [Inject]
    public void Construct(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        EnterCursor(false);
    }

    protected override void Interact()
    {
        if (_player.CheckActiveCassette(out CassetteObject currentCassette))
        {
            OnInteract?.Invoke(currentCassette);
        }
    }

    public void SetSettings(Ease ease, float time)
    {
        _ease = ease;
        _time = time;
    }

    public void ControlVisible(bool isVisible)
    {
        if (_meshRenderer.enabled == isVisible) return;
        _meshRenderer.enabled = isVisible;
        //gameObject.SetActive(isVisible);
    }

    public bool Install(CassetteObject cassetteObject, out CassetteObject tempCassette)
    {
        tempCassette = cassetteObject;
        bool isSuccessful = cassetteObject == null;

        if (isSuccessful) { return isSuccessful; }

        cassetteObject.Install(transform, _ease, _time);
        //Debug.Log($"isSuccessful {isSuccessful}");

        return isSuccessful;
    }

    public override void EnterCursor(bool isVisible)
    {
        OnEnterCursor?.Invoke(isVisible);
        //_meshRenderer.enabled = isVisible;
    }
}