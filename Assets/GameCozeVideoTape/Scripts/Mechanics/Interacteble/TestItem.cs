using System.Collections;
using UnityEngine;

public class TestItem : BazeInteracteble
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float _speedBlend;
    [SerializeField] private float _coeffBlend;
    [SerializeField] private float _minDistance;
    [SerializeField] private float _minRotation;
    private float _tempSpeedBlend;
    private bool _isActive;

    private void Start()
    {
        _tempSpeedBlend = _speedBlend;
    }

    protected override void Interact()
    {
        PickUp(_transform);
    }

    private void PickUp(Transform temptransform)
    {
        StartCoroutine(FlyToHand(temptransform));
    }

    private IEnumerator FlyToHand(Transform temptransform)
    {
        _isActive = true;
        _tempSpeedBlend = _speedBlend;
        while (_isActive)
        {
            yield return null;
            _tempSpeedBlend *= _coeffBlend;
            transform.position = Vector3.Lerp(transform.position, temptransform.position, _tempSpeedBlend * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, _transform.rotation, _tempSpeedBlend * Time.deltaTime);
            _isActive = CheckEnd(temptransform);
        }
        transform.SetParent(_transform);
    }

    private bool CheckEnd(Transform temptransform)
    {
        bool isCurrentPos = _minDistance < Vector3.Distance(transform.position, temptransform.position);
        bool isCurrentRotation = _minRotation < Quaternion.Angle(transform.rotation, temptransform.rotation);
        return isCurrentPos == true || isCurrentRotation == true;
    }
}