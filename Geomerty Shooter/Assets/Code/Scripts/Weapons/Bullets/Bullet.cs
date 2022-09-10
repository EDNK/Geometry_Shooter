using System;
using MyPooler;
using UnityEngine;

namespace Code.Scripts.Weapons.Bullets
{
    public abstract class Bullet : MonoBehaviour, IPooledObject
    {
        public float Speed { private set; get; }
        private const float DefaultSpeed = 10f;
        private string _prefabName;

        private void Awake()
        {
            Speed = DefaultSpeed;
            _prefabName = gameObject.name;
        }

        public void OnRequestedFromPool()
        {
            return;
        }

        public void DiscardToPool()
        {
            ObjectPooler.Instance.ReturnToPool(_prefabName, gameObject);
        }
    }
}