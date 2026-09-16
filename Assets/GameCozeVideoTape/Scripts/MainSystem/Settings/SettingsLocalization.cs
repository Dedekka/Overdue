using UnityEngine;

[CreateAssetMenu(fileName = "SettingsLocalization", menuName = "Create/Settings/SettingsLocalization")]
public class SettingsLocalization : ScriptableObject
{
    #region PublicField
    public Material MaterialGanre => _materialGanre;
    public Material MaterialSubGanre => _materialSubGanre;

    #endregion

    [Header("Ru")]
    [SerializeField] private Texture2DArray _ganreRu;
    [SerializeField] private Texture2DArray _subGanreRu;
    [Header("Eng")]
    [SerializeField] private Texture2DArray _ganreEng;
    [SerializeField] private Texture2DArray _subGanreEng;

    [Header("Material")]
    [SerializeField] private Material _materialGanre;
    [SerializeField] private Material _materialSubGanre;

    private static readonly int _colorTexture = Shader.PropertyToID("_Color_Texture2D_Array");

    public void SetLocalizationMaterial(Language language)
    {
        Debug.Log($"SetLocalizationMaterial, Language:{language}");
        Debug.Log($"MaterialGanre:{_materialGanre.GetTexture(_colorTexture).name}");
        Debug.Log($"MaterialSubGanre:{_materialSubGanre.GetTexture(_colorTexture).name}");
        switch (language)
        {
            case Language.En:
                _materialGanre.SetTexture(_colorTexture, _ganreEng);
                _materialSubGanre.SetTexture(_colorTexture, _subGanreEng);
                //_materialGanre.mainTexture = _GanreEng;
                //_materialSubGanre.mainTexture = _subGanreEng;
                break;

            case Language.Ru:

                _materialGanre.SetTexture(_colorTexture, _ganreRu);
                _materialSubGanre.SetTexture(_colorTexture, _subGanreRu);

                //_materialGanre.mainTexture = _GanreRu;
                //_materialSubGanre.mainTexture = _subGanreRu;
                break;

            default:
                break;
        }

        Debug.Log($"MaterialGanre:{_materialGanre.GetTexture(_colorTexture).name}");
        Debug.Log($"MaterialSubGanre:{_materialSubGanre.GetTexture(_colorTexture).name}");
    }
}
