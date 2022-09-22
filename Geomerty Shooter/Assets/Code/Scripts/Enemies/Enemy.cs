using System;
using System.Numerics;
using Code.Scripts.Weapons.Bullets;
using MyPooler;
using UnityEngine;
using Zenject;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Code.Scripts.Enemies
{
    public class Enemy : MonoBehaviour, IPooledObject
    {
        public Vector3 FallingVector { get; private set; }
        public BigInteger HealthPoints { get; private set; }

        private float _rotationSpeed = 20f;
        private float _rotationOffset;

        private float _moveSpeed = 0.6f;

        private string _prefabName;

        private void Start()
        {
            _rotationOffset = Random.Range(0, 360f);
            var fallingAngle = Random.Range(210f, 320f);
            FallingVector = new Vector3(Mathf.Cos(fallingAngle * Mathf.Deg2Rad),
                Mathf.Sin(fallingAngle * Mathf.Deg2Rad)) * _moveSpeed;
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, _rotationOffset + Time.time * _rotationSpeed);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.CompareTag("Bound"))
            {
                FallingVector = new Vector3(-FallingVector.x, FallingVector.y);
            }
        }

        public void SetupEnemy(string enemyName, BigInteger enemyHealth)
        {
            _prefabName = enemyName;
            HealthPoints = enemyHealth;
        }

        public void TakeDamage(BigInteger damage)
        {
            HealthPoints -= damage;
        }

        public void OnRequestedFromPool()
        {
            HealthPoints = 1;
        }

        public void DiscardToPool()
        {
            ObjectPooler.Instance.ReturnToPool(_prefabName, gameObject);
        }
    }
}