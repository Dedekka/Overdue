using Zenject;

public class AchievementInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSubGenreAchievement();
        BindListener();
    }


    private void BindSubGenreAchievement()
    {
        Container.Bind<ControlSubGenreAchievement>()
         .AsSingle();

        Container.Bind<SubGenreAchievement>()
         .AsTransient();
    }


    private void BindListener()
    {
        Container.BindInterfacesAndSelfTo<ListenerChangeMusic>()
         .AsSingle();

        Container.BindInterfacesAndSelfTo<ListenerStateInstallTv>()
         .AsSingle();
    }
}