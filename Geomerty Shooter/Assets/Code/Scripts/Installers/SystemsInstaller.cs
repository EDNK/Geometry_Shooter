using Code.Scripts.Systems;
using Zenject;

namespace Code.Scripts.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<PlayerMoveSystem>().AsSingle().NonLazy();
            Container.BindInterfacesTo<PlayerShootingSystem>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BulletMovableSystem>().AsSingle().NonLazy();
        }
    }
}