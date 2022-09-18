using System;
using System.Numerics;
using Code.Scripts.Enemies;
using MyPooler;
using UnityEngine;

namespace Code.Scripts.Weapons.Bullets
{
    public class Bullet : MonoBehaviour, IPooledObject
    {
        public float Speed { private set; get; }
        public BigInteger Damage { private set; get; }

        private const float DefaultSpeed = 5f;
        private BigInteger _defaultDamage = 1;
        private string _prefabName;

        public bool TouchedEnemy { get; private set; }

        public void SetupBullet(string prefabName, float speed = DefaultSpeed)
        {
            Speed = DefaultSpeed;
            _prefabName = prefabName;
            Damage = _defaultDamage;
            TouchedEnemy = false;
        }

        public void OnRequestedFromPool()
        {
        }

        public void DiscardToPool()
        {
            ObjectPooler.Instance.ReturnToPool(_prefabName, gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                return;
            }

            TouchedEnemy = true;
            enemy.TakeDamage(Damage);
        }
    }
}