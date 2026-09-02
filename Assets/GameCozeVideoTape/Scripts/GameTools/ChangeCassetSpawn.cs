using System.Collections.Generic;
using UnityEngine;

public class ChangeCassetSpawn : MonoBehaviour
{
    [SerializeField] private List<CassetteObject> _listCassetteObject;
    [SerializeField] private CassetteObject _pref;
    [SerializeField] private Transform _pool;

    [ContextMenu("ChangeSpawn")]
    private void ChangeSpawn()
    {
        for (int i = 0; i < _listCassetteObject.Count; i++)
        {
            CassetteObject tempCassette = GameObject.Instantiate(_pref, _pool);
            tempCassette.transform.position = _listCassetteObject[i].transform.position;
            tempCassette.transform.rotation = _listCassetteObject[i].transform.rotation;
        }
    }
}
