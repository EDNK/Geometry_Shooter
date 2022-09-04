using UnityEngine;
using Zenject;

namespace Code.Scripts.Systems
{
    public class SystemsRunner : MonoBehaviour
    {
        [Inject] private PlayerMoveSystem _playerMoveSystem;

        private void Update()
        {
            _playerMoveSystem.Execute();
        }
    }
}