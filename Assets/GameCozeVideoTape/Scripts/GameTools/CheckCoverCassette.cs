using UnityEngine;

public class CheckCoverCassette : MonoBehaviour
{
    [Header("DebugTexture")]
    [SerializeField, Tooltip("Тестируемая текстура")] private Texture2DArray _cover;
    [SerializeField, Range(1, 60), Tooltip("Кол-во тестируемых обложек")] private int _valueCover;

    [Header("System")]
    [SerializeField, Tooltip("Модель кассеты")] private GameObject _prefabCover;
    [SerializeField, Tooltip("Материал кассеты")] private Material _material;
    [SerializeField, Tooltip("Пложение кассет")] private Transform[] _position;

    private GameObject _coverPool;
    private static readonly int IndexTextureProperty = Shader.PropertyToID("_Texture2D_Array");
    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    private void Start()
    {
        //if (_cover.depth < i) { return; }
    }

    [ContextMenu("Spawn")]
    private void Spawn()
    {
        ChangeTexture();
        CheckPool();
        CreateCover();
    }

    private void ChangeTexture()
    {
        _material.SetTexture(IndexTextureProperty, _cover);
    }

    private void CreateCover()
    {
        for (int i = 0; i < _valueCover; i++)
        {
            GameObject tempCover = GameObject.Instantiate(_prefabCover);
            tempCover.name = $"Cover # {i}";
            tempCover.transform.position = _position[i].position;
            tempCover.transform.rotation = _position[i].rotation;
            tempCover.transform.SetParent(_coverPool.transform);
            ChangeMaterial(tempCover, i);
        }
    }


    private void ChangeMaterial(GameObject cover, int materialIndex)
    {
        Renderer renderer = cover.GetComponent<Renderer>();
        renderer.material = _material;
        MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();

        UpdateTexture(renderer, _propertyBlock, materialIndex);
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

    private void CheckPool()
    {
        if (_coverPool != null)
        {
            GameObject.DestroyImmediate(_coverPool.gameObject);
        }
        _coverPool = new GameObject("CoverPool");
        _coverPool.transform.SetParent(transform);
    }
}
