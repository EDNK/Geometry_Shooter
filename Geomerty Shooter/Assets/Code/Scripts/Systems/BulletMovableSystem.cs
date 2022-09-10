using System.Collections.Generic;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class BulletMovableSystem : IExecutiveSystem, IInitializableSystem
    {
        private readonly List<Bullet> _bullets = new List<Bullet>();
        private Camera _camera;

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Execute()
        {
            var count = _bullets.Count;
            var deleted = 0;

            for (var i = 0; i < count; i++)
            {
                if (BulletTooFar(_bullets[i - deleted]))
                {
                    var bullet = _bullets[i - deleted];
                    _bullets.RemoveAt(i - deleted);
                    Object.Destroy(bullet.gameObject);
                    deleted++;
                    continue;
                }

                _bullets[i - deleted].transform.position += _bullets[i - deleted].Speed * Vector3.up * Time.deltaTime;
            }
        }

        private bool BulletTooFar(Bullet bullet)
        {
            return _camera.pixelHeight < _camera.WorldToScreenPoint(bullet.transform.position).y;
        }

        public void AddNewBullets(IEnumerable<Bullet> bullets)
        {
            _bullets.AddRange(bullets);
        }
    }
}