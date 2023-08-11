using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInput();
    }
    
    private void BindInput()
    {
        Container.Bind<IInput>().To<InputHandlerKeyboard>().AsSingle();
    }
}