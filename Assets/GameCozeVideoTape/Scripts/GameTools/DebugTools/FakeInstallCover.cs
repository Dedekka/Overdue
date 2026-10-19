using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FakeInstallCover : MonoBehaviour
{
    private Renderer[] _renderers;
    private DataCassets _dataCassets;
    private ManagerCassette _managerCassette;

    private Transform _poolCover;

    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    [Inject]
    public void Construct(DataCassets dataCassets, ManagerCassette managerCassette)
    {
        _dataCassets = dataCassets;
        _managerCassette = managerCassette;
    }

    private void Start()
    {
        _poolCover = transform.GetChild(0);
        _renderers = _poolCover.GetComponentsInChildren<Renderer>(true);
    }

    [ContextMenu("ActiveCover")]
    public void ActiveCover()
    {
        OffCasset();
        _poolCover.gameObject.SetActive(true);
        List<int> materialIndex = new List<int>();
        materialIndex = _dataCassets.GetMaterialIndex();
        int MaterialIndex = 0;
        int tempCount = 0;
        for (int i = 0; i < _renderers.Length; i++)
        {
            if (tempCount >= materialIndex.Count)
            {
                tempCount = 0;
            }
            MaterialIndex = materialIndex[tempCount];
            ChangeMaterial(_renderers[i], MaterialIndex);
            tempCount++;
        }
    }

    private void ChangeMaterial(Renderer renderer,int MaterialIndex)
    {
        //Renderer renderer = tempCassette.GetComponent<Renderer>();
        MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();

        UpdateTexture(renderer, _propertyBlock, MaterialIndex);
    }

    private void UpdateTexture(Renderer renderer, MaterialPropertyBlock _propertyBlock, int materialIndex)
    {
        // Получаем текущий блок свойств
        renderer.GetPropertyBlock(_propertyBlock);

        // Устанавливаем индекс
        //_propertyBlock.SetTexture(IndexTextureProperty, _cover);
        _propertyBlock.SetInteger(ArrayIndexProperty, materialIndex);

        // Применяем блок свойств к рендереру
        renderer.SetPropertyBlock(_propertyBlock);
    }

    private void OffCasset()
    {
        List<CassetteObject> _listCassette = _managerCassette.ListCassette;

        for (int i = 0; i < _listCassette.Count; i++)
        {
            _listCassette[i].gameObject.SetActive(false);
        }
    }
}