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
    private SelectedItemEffect _selectedItemEffect;


    public void Initialization(SelectedItemEffect selectedItemEffect)
    {
        _selectedItemEffect = selectedItemEffect;
    }

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
            _selectedItemEffect.ControlActionOutline(_renderer[i]);
        }
    }

    public void ActiveDecor()
    {
        _item.SetActive(true);
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material = _decorMaterial;
            _selectedItemEffect.ClearEffects(_renderer[i]);
        }
    }
}
