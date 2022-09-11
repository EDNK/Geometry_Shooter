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

        public void SetupBullet(string prefabName, float speed = DefaultSpeed)
        {
            Speed = DefaultSpeed;
            _prefabName = prefabName;
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