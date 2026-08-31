using System.Collections.Generic;
using UnityEngine;

public class RenamePool : MonoBehaviour
{
    [SerializeField] private List<GameObject> _gameObject;
    [SerializeField] private string _name;
    [SerializeField] private int _startID;
    private string _tempName;
    private int _tempIndex;

    [ContextMenu("Rename")]
    private void Rename()
    {
        _tempIndex = _startID;
        
        for (int i = 0; i < _gameObject.Count; i++)
        {
            _tempName = $"{_name}{_tempIndex}";
            _gameObject[i].name = _tempName;
            _tempIndex++; 
        }
    }
}
