using System.Collections.Generic;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class BulletMovableSystem : IExecutiveSystem
    {
        private readonly List<Bullet> _bullets = new List<Bullet>();
        
        public void Execute()
        {
            foreach (var bullet in _bullets)
            {
                bullet.transform.position += bullet.Speed * Vector3.up * Time.deltaTime;
            }
        }

        public void AddNewBullets(IEnumerable<Bullet> bullets)
        {
            _bullets.AddRange(bullets);
        }
    }
}