using System.Collections.Generic;
using System.Linq;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class BulletMovableSystem : IExecutiveSystem, IInitializableSystem
    {
        private readonly Dictionary<int, Bullet> _bullets = new Dictionary<int, Bullet>();
        private Camera _camera;

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Execute()
        {
            var objectsToDelete = _bullets.Keys.Where(x => BulletTooFar(_bullets[x])).ToList();
            foreach (var expiredBullet in objectsToDelete)
            {
                var bullet = _bullets[expiredBullet];
                _bullets.Remove(expiredBullet);
                bullet.DiscardToPool();
            }

            foreach (Bullet bullet in _bullets.Keys.Select(key => _bullets[key]))
            {
                bullet.transform.position += bullet.Speed * Vector3.up * Time.deltaTime;
            }
        }

        private bool BulletTooFar(Bullet bullet)
        {
            return _camera.pixelHeight < _camera.WorldToScreenPoint(bullet.transform.position).y;
        }

        public void AddNewBullets(IEnumerable<Bullet> bullets)
        {
            foreach (var bullet in bullets)
            {
                _bullets.Add(bullet.GetInstanceID(), bullet);
            }
        }
    }
}