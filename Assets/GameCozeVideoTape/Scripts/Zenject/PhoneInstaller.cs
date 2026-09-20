using UnityEngine;
using Zenject;

public class PhoneInstaller : MonoInstaller
{
    [Header("Phone")]
    [SerializeField] private PhoneSettings _phoneSettings;
    [SerializeField] private Phone _phone;
    [SerializeField] private Transform _phoneHand;
    [SerializeField] private Transform _phoneBody;
    [SerializeField] private Transform _slot_Phone;

    public override void InstallBindings()
    {
        FindSub();
        BindPhone();
        BindPhoneEffect();
        BindImporter();
    }


    private void FindSub()
    {
        Container.Bind<PhoneSettings>()
            .FromInstance(_phoneSettings)
            .AsSingle();
    }

    private void BindPhone()
    {
        Container.Bind<Phone>()
           .FromInstance(_phone)
           .AsSingle();
    }

    private void BindPhoneEffect()
    {
        Container.Bind<PhoneEffect>()
           .AsSingle();

        Container.Bind<PhoneSound>()
           .AsSingle()
           .WithArguments(_phoneBody);

        Container.BindInterfacesAndSelfTo<PhoneAnimation>()
           .AsSingle()
           .WithArguments(_phoneBody, _phoneHand, _slot_Phone);
    }


    private void BindImporter()
    {
        Container.BindInterfacesAndSelfTo<ImporterDialogSystemCallPhoneAnimation>()
            .AsSingle();
    }

}