using Code.Scripts.Player;
using UnityEngine;
using Zenject;

namespace Code.Scripts.Systems
{
    public class PlayerMoveSystem : IExecutiveSystem
    {
        private readonly PlayerShip _playerShip;

        public PlayerMoveSystem(PlayerShip playerShip)
        {
            _playerShip = playerShip;
        }
        
        public void Execute()
        {   
            if (!Input.GetMouseButton(0))
            {
                return;
            }

            var touch = Input.mousePosition;
            var realPos = Camera.main.ScreenToWorldPoint(touch);
            _playerShip.transform.position = realPos;
        }
    }
}