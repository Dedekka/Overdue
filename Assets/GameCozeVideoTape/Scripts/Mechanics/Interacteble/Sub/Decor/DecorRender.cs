using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class DecorRender
{
    [SerializeField] private GameObject _item;
    [SerializeField] private List<Renderer> _renderer;
    private Material _slotMaterial;
    private Material _decorMaterial;

    public void SetMaterial(Material slotMaterial, Material decorMaterial)
    {
        _slotMaterial = slotMaterial;
        _decorMaterial = decorMaterial;
    }

    public void VisibleSlot(bool visible)
    {
        _item.SetActive(visible);
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material = _slotMaterial;
        }
    }

    public void ActiveDecor()
    {
        _item.SetActive(true);
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material = _decorMaterial;
        }
    }
}
