using System.Linq;
using Code.Scripts.AssetsResources;
using Code.Scripts.Player;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class PlayerShootingSystem : IExecutiveSystem, IInitializableSystem
    {
        private readonly PlayerShip _playerShip;
        private readonly AssetDictionary _assetDictionary;
        private readonly BulletMovableSystem _bulletMovableSystem;

        private Transform _bulletParent; 
        private float _lastShotTime = 0;

        public PlayerShootingSystem(PlayerShip playerShip, AssetDictionary assetDictionary, BulletMovableSystem bulletMovableSystem)
        {
            _playerShip = playerShip;
            _assetDictionary = assetDictionary;
            _bulletMovableSystem = bulletMovableSystem;
        }
        
        public void Initialize()
        {
            _bulletParent = new GameObject("BulletsParent").transform;
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
            var weapon = _playerShip.GetWeapon();
            var transforms = _playerShip.GetSuitableFirePosTransforms(weapon.GetMaxBulletsAtShot());
            var bulletPrefab = _assetDictionary.GetAsset(weapon.GetBulletPrefabName()).GetComponent<Bullet>();
            //TODO WRITE A BULLET FACTORY
            
            var bulletsToInstantiate = transforms.Select(transform =>
                Object.Instantiate(bulletPrefab, transform.position, Quaternion.identity, _bulletParent)).ToList();
            
            _bulletMovableSystem.AddNewBullets(bulletsToInstantiate);
        }

        private bool CanShoot()
        {
            return Time.time > _lastShotTime + _playerShip.GetShootCooldown();
        }
    }
}