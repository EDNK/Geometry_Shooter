using Code.Scripts.Player;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class PlayerShootingSystem : IExecutiveSystem
    {
        private readonly PlayerShip _playerShip;
        private float _lastShotTime = 0;

        public PlayerShootingSystem(PlayerShip playerShip)
        {
            _playerShip = playerShip;
        }

        public void Execute()
        {
            if (Input.GetMouseButton(0) && CanShoot())
            {
                PerformShoot();
            }
        }

        private void PerformShoot()
        {
            _lastShotTime = Time.time;
            //var weapon = _playerShip.GetWeapon();
            //var positions = _playerShip.GetSuitableFirePosTransforms();
            //var fireBullet = weapon.GetBullet();
            //foreach(var pos in positions){
            // TODO instantiate new prefab
            //}
        }

        private bool CanShoot()
        {
            return Time.time > _lastShotTime + _playerShip.GetShootCooldown();
        }
    }
}