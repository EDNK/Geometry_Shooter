using System.Collections.Generic;
using System.Linq;
using Code.Scripts.AssetsResources;
using Code.Scripts.Player;
using Code.Scripts.ShellObjects;
using Code.Scripts.Weapons.Bullets;
using MyPooler;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class PlayerShootingSystem : IExecutiveSystem
    {
        private readonly PlayerShip _playerShip;
        private readonly AssetDictionary _assetDictionary;
        private readonly AliveBullets _aliveBullets;

        private float _lastShotTime = 0;

        public PlayerShootingSystem(PlayerShip playerShip, AssetDictionary assetDictionary, AliveBullets aliveBullets)
        {
            _playerShip = playerShip;
            _assetDictionary = assetDictionary;
            _aliveBullets = aliveBullets;
        }

        public void Execute()
        {
            if (CanShoot() && Input.GetMouseButton(0))
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

            var bulletsToInstantiate = CreateBullets(transforms, bulletPrefab);
            bulletsToInstantiate.ForEach(x => x.SetupBullet(bulletPrefab.name));

            _aliveBullets.AddBullets(bulletsToInstantiate);
        }

        private List<Bullet> CreateBullets(IEnumerable<Transform> transforms, Bullet bulletPrefab)
        {
            var bulletsToInstantiate = new List<Bullet>(5);
            bulletsToInstantiate.AddRange(transforms
                .Select(transform =>
                    ObjectPooler.Instance.GetFromPool(bulletPrefab.name, transform.position, quaternion.identity))
                .Select(newBullet => newBullet.GetComponent<Bullet>()));
            return bulletsToInstantiate;
        }

        private bool CanShoot()
        {
            return Time.time > _lastShotTime + _playerShip.GetShootCooldown();
        }
    }
}