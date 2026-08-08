using UnityEngine;

public class ReturnedMover 
{
    private ManagerCassette _managerCassette;
    private Transform _returnedPosition;

    public ReturnedMover(ManagerCassette managerCassette, Transform position)
    {
        _managerCassette = managerCassette;
        _returnedPosition = position;
    }

    public void Returned(int id)
    {
        if (_managerCassette.CassetsDictionary.TryGetValue(id, out CassetteObject cassette))
        {
            cassette.transform.position = _returnedPosition.position;
            cassette.transform.rotation = _returnedPosition.rotation;
            cassette.Drop();
        }
        else
        {
            Debug.LogError($"ReturnedMover, Not Found Cassette, ID: {id}");
        }
    }
}