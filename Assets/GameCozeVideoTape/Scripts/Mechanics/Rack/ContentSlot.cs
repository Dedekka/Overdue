using DG.Tweening;
using System;
using UnityEngine;

public class ContentSlot : BazeInteracteble
{
    [SerializeField] private Ease Ease;
    [SerializeField] private float _time;
    private MeshRenderer _meshRenderer;

    public event Action OnInteract;
    public event Action<bool> OnEnterCursor;

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
        OnInteract?.Invoke();
    }

    public void ControlVisible(bool isVisible)
    {
        _meshRenderer.enabled = isVisible;
        //gameObject.SetActive(isVisible);
    }

    public bool Install(CassetteObject cassetteObject, out CassetteObject tempCassette)
    {
        tempCassette = cassetteObject;
        bool isSuccessful = cassetteObject == null;

        if (isSuccessful) { return isSuccessful; }

        cassetteObject.Install(transform, Ease, _time);
        Debug.Log($"isSuccessful {isSuccessful}");

        return isSuccessful;
    }

    public override void EnterCursor(bool isVisible)
    {
        OnEnterCursor?.Invoke(isVisible);
        //_meshRenderer.enabled = isVisible;
    }
}