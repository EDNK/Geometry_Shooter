using Code.Scripts.ShellObjects;
using Zenject;

namespace Code.Scripts.Installers
{
    public class ShellObjectsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<AliveBullets>().AsSingle();
        }
    }
}
