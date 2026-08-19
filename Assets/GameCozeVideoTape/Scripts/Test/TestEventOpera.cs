using UnityEngine;

public class TestEventOpera : BazeInteracteble
{
    [SerializeField] private TV _tV;
    [SerializeField] private int _id;
    
    private void Awake()
    {
        _isShowPanelUse = true;
    }

    protected override void Interact()
    {
        //_tV.SetIdEpisode(_id);
    }
}