using System.Collections.Generic;
using UnityEngine;

public class ResetIdCassette : MonoBehaviour
{
    [SerializeField] private List<CassetteObject> _listCassette;
    [SerializeField] private int _startId;

    [ContextMenu("ResetId")]
    private void SetId()
    {
        int id = _startId;
        CassetteObject tempCassetteObject;
        for (int i = 0; i < _listCassette.Count; i++)
        {
            tempCassetteObject = _listCassette[i];
            tempCassetteObject.SetId(id);
            tempCassetteObject.gameObject.name = $"Cassette_Id_{id}";
            id++;
        }
    }
}
