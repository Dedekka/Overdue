using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Zenject;
using Random = UnityEngine.Random;

public class RundomChangerSteamState : IInitializable, IDisposable
{
    private ControlSteamState _controlSteamState;
    private CancellationTokenSource _cancellationToken;
    private CounterSlotCassette _counterSlotCassette;
    private string[] _states;
    public RundomChangerSteamState(ControlSteamState controlSteamState, CounterSlotCassette counterSlotCassette)
    {
        _counterSlotCassette = counterSlotCassette;
        _controlSteamState = controlSteamState;
        _cancellationToken = new CancellationTokenSource();
        _states = new string[]
       {
            DataSteamStateKey.GameplayV1,
            DataSteamStateKey.GameplayV2,
            DataSteamStateKey.GameplayV3,
            DataSteamStateKey.GameplayV4,
            DataSteamStateKey.GameplayV5,
       };
    }

    public void Initialize()
    {
        ActiveChangerSteamState(_cancellationToken.Token).Forget();
    }



    public void Dispose()
    {
        _cancellationToken?.Cancel();
        _cancellationToken?.Dispose();
        _cancellationToken = null;
    }

    public async UniTaskVoid ActiveChangerSteamState(CancellationToken token)
    {
        while (true)
        {
            await UniTask.Delay(TimeSpan.FromMinutes(3), cancellationToken: token);
            ChangeState();
        }
    }

    public void ChangeState()
    {
        UpdateCountCassets();
        string newState = GetNewState();
        _controlSteamState.SetPlayerState(newState);
    }

    private string GetNewState()
    {
        int index = Random.Range(0, _states.Length);
        return _states[index];
    }

    private void UpdateCountCassets()
    {
        _controlSteamState.SetCountInstall(_counterSlotCassette.CountSuccessInstall.ToString());
    }
}