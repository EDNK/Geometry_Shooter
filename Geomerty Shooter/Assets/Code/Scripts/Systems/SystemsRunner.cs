using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Systems
{
    public class SystemsRunner : MonoBehaviour
    {
        private List<IExecutiveSystem> _executiveSystems;
        private List<IInitializableSystem> _initializableSystems;

        [Inject]
        public void Init(List<IExecutiveSystem> executiveSystems, List<IInitializableSystem> initializableSystems)
        {
            _executiveSystems = executiveSystems;
            _initializableSystems = initializableSystems;
        }

        private void Awake()
        {
            _initializableSystems.ForEach(x => x.Initialize());
        }

        private void Update()
        {
            _executiveSystems.ForEach(x => x.Execute());
        }
    }
}