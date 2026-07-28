using UnityEngine;

public class SpawnerCassette : MonoBehaviour
{
    [SerializeField] private GameObject _poolCassette;
    [SerializeField] private CassetteObject _prepabCassette;
    //[SerializeField, Min(1)] private int _value;
    //[SerializeField] private int _startId;
    [SerializeField, Min(1)] private int _width = 10;
    [SerializeField, Min(1)] private int _length = 45;
    [SerializeField] private float _coeffOfcetWidth = 0.5f;
    [SerializeField] private float _coeffOfcetLength = 0.5f;


    private Vector3 _position;

    [ContextMenu("Spawn")]
    public void Spawn()
    {
        _position = _poolCassette.transform.position;
        CassetteObject tempCassette;
        for (int i = 0; i < _width; i++)
        {
            for (int j = 0; j < _length; j++)
            {
                tempCassette = GameObject.Instantiate(_prepabCassette, _poolCassette.transform);
                _position.x = j * _coeffOfcetLength;
                tempCassette.transform.position += _position;
                //tempCassette.transform.forward = Vector3.down;
                //tempCassette.transform.rotation = Quaternion.AngleAxis(90,Vector3.up);
                tempCassette.transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.left);
                //tempCassette.SetId(_startId);
                //_startId++;
            }
            _position.z = i * _coeffOfcetWidth;
        }
    }
}