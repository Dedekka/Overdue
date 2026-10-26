using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GarlandController : MonoBehaviour
{
    [SerializeField] private List<Renderer> _garlands;
    private GarlandRender _garlandRender;
    private EffectSettings _effectSettings;
    private FinderFreeSlot _finderFreeSlot;
    private ControlSteamAchievement _controlSteamAchievement;
    private AudioManager _audioManager;
    private Rack _rack;
    private int _maxLamp;
    private int _freeSlot;


    [Inject]
    public void Construct(GarlandRender garlandRender, EffectSettings effectSettings, FinderFreeSlot finderFreeSlot, ControlSteamAchievement controlSteamAchievement, AudioManager audioManager)
    {
        _audioManager = audioManager;
        _garlandRender = garlandRender;
        _effectSettings = effectSettings;
        _finderFreeSlot = finderFreeSlot;
        _maxLamp = _garlands.Count;
        _controlSteamAchievement = controlSteamAchievement;
    }

    private void Awake()
    {
        _rack = GetComponent<Rack>();
    }

    private void Start()
    {
        _freeSlot = _finderFreeSlot.CountFreeSlot(_rack);
    }

    private void OnEnable()
    {
        _rack.OnChanheCountSuccessInstall += CheckContinueInstall;
    }

    private void OnDisable()
    {
        _rack.OnChanheCountSuccessInstall -= CheckContinueInstall;
    }

    private void CheckContinueInstall()
    {
        if (_rack.CountSuccessInstall == _freeSlot)
        {
            _rack.OnChanheCountSuccessInstall -= CheckContinueInstall;
            StartEffect().Forget();
            _audioManager.PlayGarlandActive();
            _controlSteamAchievement.SetAchievement(DataAchievement.ACHIEVEMENT_2);
        }
    }

    [ContextMenu("StartEffect")]
    public async UniTask StartEffect()
    {
        for (int i = 0; i < _garlands.Count; i++)
        {
            await ChangeLight(_garlands[i], i);
        }
        OnDisable();
    }

    private async UniTask ChangeLight(Renderer lamp, int count)
    {
        float coefficient = (float)count / _maxLamp;
        coefficient = 1 - coefficient;

        Debug.Log($"count:{count}, _maxLamp:{_maxLamp} coefficient:{coefficient}, EmissiveSpeed:{_effectSettings.EmissiveSpeed * coefficient}");
        bool isComplited = false;
        float emissiveStrengh = _effectSettings.EmissiveStrenghRange.x;
        DOTween.To(() => emissiveStrengh, x => emissiveStrengh = x, _effectSettings.EmissiveStrenghRange.y, _effectSettings.EmissiveSpeed * coefficient)
            .SetEase(Ease.InOutBounce)
            .OnUpdate(() => _garlandRender.ChangeLight(lamp, emissiveStrengh))
            .OnComplete(() => isComplited = true)
            .Play();

        await UniTask.WaitUntil(() => isComplited);
    }
}