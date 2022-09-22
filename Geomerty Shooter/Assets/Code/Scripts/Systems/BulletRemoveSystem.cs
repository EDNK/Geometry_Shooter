using System.Collections.Generic;
using Code.Scripts.ShellObjects;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class BulletRemoveSystem : IInitializableSystem, IExecutiveSystem
    {
        private readonly List<Bullet> _aliveBullets;
        private Camera _camera;

        public BulletRemoveSystem(AliveBullets aliveBullets)
        {
            _aliveBullets = aliveBullets.Bullets;
        }

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Execute()
        {
            for (var i = _aliveBullets.Count - 1; i >= 0; i--)
            {
                if (!BulletTooFar(_aliveBullets[i]) && !_aliveBullets[i].HaveToDestroy)
                {
                    continue;
                }

                RemoveBulletFromList(i);
            }
        }

        private void RemoveBulletFromList(int i)
        {
            var bullet = _aliveBullets[i];
            bullet.DiscardToPool();
            _aliveBullets[i] = _aliveBullets[_aliveBullets.Count - 1];
            _aliveBullets.RemoveAt(_aliveBullets.Count - 1);
        }

        private bool BulletTooFar(Bullet bullet)
        {
            return _camera.pixelHeight < _camera.WorldToScreenPoint(bullet.transform.position).y;
        }
    }
}