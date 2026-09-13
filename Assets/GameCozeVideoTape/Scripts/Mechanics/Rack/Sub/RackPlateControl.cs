using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RackPlateControl : IInitializable
{
    private DataGenre _dataGenre;
    private SettingsLocalization _settingsLocalization;
    private PlateRenderer _plateRenderer;

    private ControlSettings _controlSettings;
    //private Language _language;

    public RackPlateControl(DataGenre dataGenre, SettingsLocalization settingsLocalization, PlateRenderer plateRenderer, ControlSettings controlSettings)
    {
        _dataGenre = dataGenre;
        _settingsLocalization = settingsLocalization;
        _plateRenderer = plateRenderer;
        _controlSettings = controlSettings;
    }

    public void Initialize()
    {
        _settingsLocalization.SetLocalizationMaterial(_controlSettings.Language);
    }

    public void SetMainGanre(GameObject mainGanre, int Id)
    {
        int materialIndex = _dataGenre.GetGenreSettingsForId(Id).MaterialIndex;
        //_language = _controlSettings.Language;

        _plateRenderer.SetViewGanre(mainGanre, _settingsLocalization.MaterialGanre, materialIndex);

        // с помощью ID € должен найти в DataGenre
        // Id material после этого вз€ть действующую локализацию
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
            _plateRenderer.SetViewGanre(tempsubGanre, _settingsLocalization.MaterialSubGanre, materialIndex);
        }

        // ћне нужно найти по Genreindex и SubGenreindex нужный materialIndex



    }


}