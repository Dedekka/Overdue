using DG.Tweening;
using UnityEngine;

public class TestItem : BazeInteracteble
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 _ve;
    protected override void Interact()
    {
        //gameObject.SetActive(false);
        PickUp(_transform);
    }

    private void PickUp(Transform temptransform)
    {
        transform.SetParent(temptransform);
        transform.DOLocalMove(Vector3.zero, 2f).Play();
        transform.DOLocalRotate(_ve, 2f).Play();
        //transform.DOLocalRotateQuaternion(Quaternion.FromToRotation(transform.forward, temptransform.forward),2f).Play();
    }
}