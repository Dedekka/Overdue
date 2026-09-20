using DG.Tweening;
using UnityEngine;
using Zenject;

public class PhoneAnimation : IInitializable
{
    private float _timePhoneBody;
    private Transform _phoneBody;
    private Transform _phoneHand;
    private Transform _slot_Phone;
    private Quaternion _startRotationPhoneBody;
    private Vector3 _startPosPhoneHand;
    private Quaternion _startRotationPhoneHand;
    
    private Tween _ringAnimation;


    public PhoneAnimation(Transform phoneBody, Transform phoneHand, Transform slot_Phone, PhoneSettings phoneSettings)
    {
        _phoneBody = phoneBody;
        _phoneHand = phoneHand;
        _slot_Phone = slot_Phone;
        _timePhoneBody = phoneSettings.TimePhoneBody;
    }

    public void Initialize()
    {
        _startRotationPhoneBody = _phoneBody.rotation;
        _startPosPhoneHand = _phoneHand.position;
        _startRotationPhoneHand = _phoneHand.rotation;
    }

    public void ActivationRingAnimation()
    {
        Quaternion quat = Quaternion.AngleAxis(5, Vector3.right);
        _ringAnimation = _phoneBody.DORotate(quat.eulerAngles, _timePhoneBody, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad)
            .Play();
        //_body.do
    }

    public void DeactivationRingAnimation()
    {
        _ringAnimation?.Kill();
        _phoneBody.rotation = _startRotationPhoneBody;
    }

    public void ActivationCallAnimation()
    {
        _phoneHand.DOMove(_slot_Phone.position, 1f)
            .SetEase(Ease.InOutSine)
            .Play();

        _phoneHand.DORotate(_slot_Phone.rotation.eulerAngles,1f,RotateMode.FastBeyond360)
            .SetEase(Ease.InOutSine)
            .Play();
    }
    
    public void DeactivationCallAnimation()
    {
        _phoneHand.DOMove(_startPosPhoneHand, 1f)
            .SetEase(Ease.InOutSine)
            .Play();

        _phoneHand.DORotate(_startRotationPhoneHand.eulerAngles, 1f, RotateMode.FastBeyond360)
          .SetEase(Ease.InOutSine)
          .Play();
    }

  
}
