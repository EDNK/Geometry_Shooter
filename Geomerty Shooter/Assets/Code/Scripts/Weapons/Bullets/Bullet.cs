using System;
using MyPooler;
using UnityEngine;

namespace Code.Scripts.Weapons.Bullets
{
    public class Bullet : MonoBehaviour, IPooledObject
    {
        public float Speed { private set; get; }
        private const float DefaultSpeed = 10f;
        private string _prefabName;
        
        public void SetupBullet()
        {
            Speed = DefaultSpeed;
            _prefabName = gameObject.name;
        }

        public void OnRequestedFromPool()
        {
        }

        public void DiscardToPool()
        {
            ObjectPooler.Instance.ReturnToPool(_prefabName, gameObject);
        }
    }
}