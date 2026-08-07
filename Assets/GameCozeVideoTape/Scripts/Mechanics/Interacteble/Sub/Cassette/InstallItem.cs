using DG.Tweening;
using System;
using UnityEngine;

public class InstallItem
{
    //public CassetteObject CassetteObject => _cassette;
    private Sequence _sequence;
    private CassetteObject _cassette;
    private Transform _body;

    public InstallItem()
    {

    }

    public void SetBody(CassetteObject transform)
    {
        _cassette = transform;
        _body = _cassette.transform;
    }

    public void StopInstall()
    {
        if(_sequence != null)
        {
            _sequence.Complete(true);
        }
    }

    public void Install(Transform transform, Ease Ease, float _time,Action action)
    {
        _body.SetParent(null);

        _sequence = DOTween.Sequence();
        _sequence.Append(
            _body.DOMove(transform.position, _time)
            .SetEase(Ease));
        _sequence.Join(
            _body.DORotateQuaternion(transform.rotation, _time)
            .SetEase(Ease));

        _sequence.OnComplete(() => action?.Invoke()); //_cassette.Control(true, true));
        _sequence.SetLink(_body.gameObject);
        _sequence.Play();
    }
}