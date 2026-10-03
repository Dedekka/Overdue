using UnityEngine;
using Zenject;

public class PlayerSay : MonoBehaviour
{
    private PlayerSaySystem _playerSaySystem;
    [Inject]
    public void Construct(PlayerSaySystem playerSaySystem)
    {
        _playerSaySystem = playerSaySystem;
    }

    public void ActiveDialogue(int idDialogue)
    {
        _playerSaySystem.ActiveDialogue(idDialogue);
    }
}