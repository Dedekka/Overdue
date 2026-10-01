public class GoalContext
{
    public readonly ListenerInputMove ListenerInputMove;
    public readonly ListenerInventory ListenerInventory;
    public readonly ListenerPlayerUi ListenerPlayerUi;
    public readonly ListenerTv ListenerTv;
    public readonly ListenerPhone ListenerPhone;
    public readonly ListenerPresentSystem ListenerPresentSystem;
    public readonly ListenerAudioRecorder ListenerAudioRecorder;

    public GoalContext
        (
        ListenerInputMove listenerInputMove,
        ListenerPlayerUi listenerPlayerUi,
        ListenerInventory listenerInventory,
        ListenerTv listenerTv,
        ListenerPhone listenerPhone,
        ListenerPresentSystem listenerPresentSystem,
        ListenerAudioRecorder listenerAudioRecorder
        )
    {
        ListenerInputMove = listenerInputMove;
        ListenerInventory = listenerInventory;
        ListenerPlayerUi = listenerPlayerUi;
        ListenerTv = listenerTv;
        ListenerPhone = listenerPhone;
        ListenerPresentSystem = listenerPresentSystem;
        ListenerAudioRecorder = listenerAudioRecorder;
    }
}