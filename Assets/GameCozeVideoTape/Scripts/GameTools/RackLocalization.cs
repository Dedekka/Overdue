using System.Collections.Generic;
using UnityEngine;

public class RackLocalization : MonoBehaviour
{
    private RackGanre[] _rackGanres;

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
        _rackGanres = GameObject.FindObjectsByType<RackGanre>(FindObjectsInactive.Include,FindObjectsSortMode.None);

        for (int i = 0; i < _rackGanres.Length; i++)
        {
            _rackGanres[i].SetLocalization();
        }
    }

}
