using Code.Scripts.ShellObjects;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class BulletMovableSystem : IExecutiveSystem
    {
        private readonly AliveBullets _aliveBullets;

        public BulletMovableSystem(AliveBullets aliveBullets)
        {
            _aliveBullets = aliveBullets;
        }

        public void Execute()
        {
            foreach (var bullet in _aliveBullets.Bullets)
            {
                bullet.transform.position += bullet.Speed * Vector3.up * Time.deltaTime;
            }
        }
    }
}