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
            Container.BindInterfacesTo<BulletMovableSystem>().AsSingle().NonLazy();
            Container.BindInterfacesTo<BulletRemoveSystem>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemySpawningSystem>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyMoveSystem>().AsSingle().NonLazy();
            Container.BindInterfacesTo<EnemyRemoveSystem>().AsSingle().NonLazy();
        }
    }
}