using System.Collections.Generic;
using System.Linq;
using Code.Scripts.ShellObjects;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class BulletMovableSystem : IExecutiveSystem
    {
        private readonly AliveBullets _aliveBullets;
        private readonly Dictionary<int, Bullet> _bullets = new Dictionary<int, Bullet>();

        public BulletMovableSystem(AliveBullets aliveBullets)
        {
            _aliveBullets = aliveBullets;
        }

        public void Execute()
        {
            foreach (var bullet in _aliveBullets.GetBullets())
            {
                bullet.transform.position += bullet.Speed * Vector3.up * Time.deltaTime;
            }
        }
    }
}