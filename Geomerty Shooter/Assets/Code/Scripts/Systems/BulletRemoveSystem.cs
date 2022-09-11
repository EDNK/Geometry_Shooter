using System.Linq;
using Code.Scripts.ShellObjects;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class BulletRemoveSystem : IInitializableSystem, IExecutiveSystem
    {
        private readonly AliveBullets _aliveBullets;
        private Camera _camera;

        public BulletRemoveSystem(AliveBullets aliveBullets)
        {
            _aliveBullets = aliveBullets;
        }

        public void Initialize()
        {
            _camera = Camera.main;
        }

        public void Execute()
        {
            var objectsToDelete = _aliveBullets.GetBullets().Where(BulletTooFar)
                .Select(x => x.gameObject.GetInstanceID());

            _aliveBullets.RemoveBullets(objectsToDelete);
        }

        private bool BulletTooFar(Bullet bullet)
        {
            return _camera.pixelHeight < _camera.WorldToScreenPoint(bullet.transform.position).y;
        }
    }
}