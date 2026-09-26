using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RackLocalization : MonoBehaviour
{
    [SerializeField] private DataGenre _dataGenre;
    [SerializeField] private SettingsLocalization _settingsLocalization;
    private RackGanre[] _rackGanres;

    private Renderer _renderer;
    private MaterialPropertyBlock _propertyBlock;
    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    [ContextMenu("Ru")]
    private void SetRuLocalized()
    {
        Localized(Language.Ru);
    }

    [ContextMenu("Eng")]
    private void SetEngLocalized()
    {
        Localized(Language.En);
    }


    private void Localized(Language language)
    {
        _rackGanres = GameObject.FindObjectsByType<RackGanre>(FindObjectsSortMode.None);
        _settingsLocalization.SetLocalizationMaterial(language);
        for (int i = 0; i < _rackGanres.Length; i++)
        {
            _rackGanres[i].SetEditor(out GameObject mainGanre, out List<GameObject> subGanreList, out Rack rack);

            SetMainGanre(mainGanre, (int)rack.Genre);
            SetSubGanre(subGanreList, rack.SubGenreShelfs, (int)rack.Genre);
            //_rackGanres[i].SetLocalization();
        }
    }

    public void SetMainGanre(GameObject mainGanre, int Id)
    {
        int materialIndex = _dataGenre.GetGenreSettingsForId(Id).MaterialIndex;
        //_language = _controlSettings.Language;

        SetViewGanre(_settingsLocalization.MaterialGanre,mainGanre, materialIndex);

        // с помощью ID я должен найти в DataGenre
        // Id material после этого взять действующую локализацию
        // из ControlSettings, и применить текстуру с индексом к материалу через PlateRenderer

    }

    public void SetSubGanre(List<GameObject> subGanre, List<DataShelf> SubGenreShelfs, int indexGanre)
    {
        if (subGanre.Count != SubGenreShelfs.Count)
        {
            Debug.LogError("RackPlateControl, SetSubGanre Not Found Full DataShelf");
            return;
        }

        GameObject tempsubGanre;
        DataShelf tempDataShelf;

        for (int i = 0; i < subGanre.Count; i++)
        {
            tempsubGanre = subGanre[i];
            tempDataShelf = SubGenreShelfs[i];
            int IndexGanre = indexGanre;
            //int IndexGanre = tempDataShelf.SubGenreShelfs.Genreindex;
            int IndexSubGanre = tempDataShelf.SubGenreindex;
            int materialIndex = _dataGenre.GetSubGenreSettingsForId(IndexGanre, IndexSubGanre).MaterialIndex;
            SetViewGanre(_settingsLocalization.MaterialSubGanre, tempsubGanre, materialIndex);
        }

        // Мне нужно найти по Genreindex и SubGenreindex нужный materialIndex



    }


    private void SetViewGanre(Material material, GameObject gameObject, int MaterialIndex)
    {
        TryGetRenderer(gameObject);

        _renderer.material = material;
        _propertyBlock = new MaterialPropertyBlock();

        // Получаем текущий блок свойств
        _renderer.GetPropertyBlock(_propertyBlock);

        // Устанавливаем индекс
        _propertyBlock.SetInteger(ArrayIndexProperty, MaterialIndex);

        // Применяем блок свойств к рендереру
        _renderer.SetPropertyBlock(_propertyBlock);
    }

    private void TryGetRenderer(GameObject gameObject)
    {
        _renderer = gameObject.GetComponent<Renderer>();
        if (_renderer == null)
        {
            _renderer = gameObject.GetComponentInChildren<Renderer>();
        }
    }

}
