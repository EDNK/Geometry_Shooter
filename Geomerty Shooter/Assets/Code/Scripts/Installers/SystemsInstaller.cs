using System.ComponentModel;
using Code.Scripts.Player;
using Code.Scripts.Systems;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Installers
{
    public class SystemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerMoveSystem>().AsSingle().NonLazy();
        }
    }
}
