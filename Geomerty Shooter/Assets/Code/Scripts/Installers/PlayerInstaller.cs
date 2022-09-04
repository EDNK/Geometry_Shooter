using Code.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerShip _playerShip;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerShip>().FromInstance(_playerShip).AsSingle().NonLazy();
        }
    }
}