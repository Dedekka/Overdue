using UnityEngine;
using Zenject;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private Transform _teleportedPos;
    private CutsceneBlackScreen _cutsceneBlackScreen;
    private ReturnedMover _returnedMover;
    private PresentEffect _presentEffect;

    [Inject]
    public void Construct(CutsceneBlackScreen cutsceneBlackScreen, ReturnedMover returnedMover, PresentEffect presentEffect)
    {
        _cutsceneBlackScreen = cutsceneBlackScreen;
        _returnedMover = returnedMover;
        _presentEffect = presentEffect;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            TeleportedPlayer(player);
            return;
        }

        if (other.TryGetComponent(out CassetteObject CassetteObject))
        {
            TeleportedCassette(CassetteObject);
        }
    }

    private void TeleportedPlayer(Player player)
    {
        _cutsceneBlackScreen.ControlView(true);
        _cutsceneBlackScreen.ActiveBlackScreen(0, 2);
        player.CharacterController.enabled = false;
        player.transform.position = _teleportedPos.position;
        player.CharacterController.enabled = true;
    }

    private void TeleportedCassette(CassetteObject cassette)
    {
        cassette.Rigidbody.isKinematic = false;
        _presentEffect.ActiveEffectReturned();
        _returnedMover.Returned(cassette);
    }
}