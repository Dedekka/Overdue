using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RackLocalization : EditorWindow
{
    //[SerializeField] private DataGenre _dataGenre;
    //[SerializeField] private SettingsLocalization _settingsLocalization;
    //private RackGanre[] _rackGanres;

    
    
    private static readonly int ArrayIndexProperty = Shader.PropertyToID("_IndexSlice");

    //[ContextMenu("Ru")]
    [MenuItem("Tools/InstallTexture/Rack/Ru")]
    private static void SetRuLocalized()
    {
        Localized(Language.Ru);
    }

    //[ContextMenu("Eng")]
    [MenuItem("Tools/InstallTexture/Rack/Eng")]
    private static void SetEngLocalized()
    {
        Localized(Language.En);
    }


    private static void Localized(Language language)
    {
        RackGanre[] _rackGanres = GameObject.FindObjectsByType<RackGanre>(FindObjectsSortMode.None);

        DataGenre _dataGenre = AssetDatabase.LoadAssetAtPath<DataGenre>(PathConst.DataGenrePath);
        SettingsLocalization _settingsLocalization = AssetDatabase.LoadAssetAtPath<SettingsLocalization>("Assets/Resources/Settings/SettingsLocalization.asset");

        _settingsLocalization.SetLocalizationMaterial(language);
        for (int i = 0; i < _rackGanres.Length; i++)
        {
            _rackGanres[i].SetEditor(out GameObject mainGanre, out List<GameObject> subGanreList, out Rack rack);


            SetMainGanre(mainGanre, (int)rack.Genre, _settingsLocalization, _dataGenre);
            SetSubGanre(subGanreList, rack.SubGenreShelfs, (int)rack.Genre, _settingsLocalization, _dataGenre);
            //_rackGanres[i].SetLocalization();
        }
    }

    public static void SetMainGanre(GameObject mainGanre, int Id, SettingsLocalization _settingsLocalization, DataGenre _dataGenre)
    {
        int materialIndex = _dataGenre.GetGenreSettingsForId(Id).MaterialIndex;
        //_language = _controlSettings.Language;

        SetViewGanre(_settingsLocalization.MaterialGanre,mainGanre, materialIndex);

        // с помощью ID я должен найти в DataGenre
        // Id material после этого взять действующую локализацию
        // из ControlSettings, и применить текстуру с индексом к материалу через PlateRenderer

    }

    public static void SetSubGanre(List<GameObject> subGanre, List<DataShelf> SubGenreShelfs, int indexGanre, SettingsLocalization _settingsLocalization, DataGenre _dataGenre)
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


    private static void SetViewGanre(Material material, GameObject gameObject, int MaterialIndex)
    {
        TryGetRenderer(gameObject, out Renderer _renderer);

        _renderer.material = material;
         MaterialPropertyBlock _propertyBlock = new MaterialPropertyBlock();

        // Получаем текущий блок свойств
        _renderer.GetPropertyBlock(_propertyBlock);

        // Устанавливаем индекс
        _propertyBlock.SetInteger(ArrayIndexProperty, MaterialIndex);

        // Применяем блок свойств к рендереру
        _renderer.SetPropertyBlock(_propertyBlock);
    }

    private static void TryGetRenderer(GameObject gameObject, out Renderer _renderer)
    {
          _renderer = gameObject.GetComponent<Renderer>();
        if (_renderer == null)
        {
            _renderer = gameObject.GetComponentInChildren<Renderer>();
        }
    }

}
