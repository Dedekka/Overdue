using UnityEngine;
using Zenject;

public class Cat : MonoBehaviour
{
    private ControlSteamAchievement _controlSteamAchievement;
    private CatTrigger _catTrigger;
    private Animator _catAnimator;
    private CatAnimation _catAnimation;
    private CatSound _catSound;
    private HeartEvent _heartEvent;


    [Inject]
    public void Construct(CatAnimation catAnimation, CatTrigger catTrigger, ControlSteamAchievement controlSteamAchievement, CatSound catSound)
    {
        _controlSteamAchievement = controlSteamAchievement;
        _catAnimation = catAnimation;
        _catTrigger = catTrigger;
        _catSound = catSound;
        _catAnimator = GetComponentInChildren<Animator>();
        _heartEvent = GetComponentInChildren<HeartEvent>();
    }

    private void OnEnable()
    {
        _catTrigger.OnChangeState += OnChangeStatePlaying;
        _heartEvent.OnHeartEvent += OnHeartEvent;
    }

    private void OnDisable()
    {
        _heartEvent.OnHeartEvent -= OnHeartEvent;
        _catTrigger.OnChangeState -= OnChangeStatePlaying;
    }

    private void Start()
    {
        _catSound.PlaySoundIdle();
        _catAnimation.Initialization(_catAnimator);
    }

    private void OnChangeStatePlaying()
    {
        _catAnimation.TryActive();
    }

    private void OnHeartEvent()
    {
        _catSound.PlaySoundMeow();
        _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_29);
        _catAnimation.OnHeartEvent();
    }
}