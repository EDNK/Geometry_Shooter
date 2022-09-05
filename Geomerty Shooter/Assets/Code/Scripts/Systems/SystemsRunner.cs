using System.Collections.Generic;
using Code.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Systems
{
    public class SystemsRunner : MonoBehaviour
    {
        private List<IExecutiveSystem> _systems;

        [Inject]
        public void Init(List<IExecutiveSystem> systems)
        {
            _systems = systems;
        }

        private void Update()
        {
            _systems.ForEach(x => x.Execute());
        }
    }
}