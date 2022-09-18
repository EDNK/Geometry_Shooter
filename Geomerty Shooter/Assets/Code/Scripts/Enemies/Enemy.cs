using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Scripts.Enemies
{
    public class Enemy : MonoBehaviour
    {
        private float _rotationSpeed = 5f;
        private float _rotationOffset;

        private void Start()
        {
            _rotationOffset = Random.Range(0, 360f);
        }

        private void Update()
        {
            transform.rotation = Quaternion.Euler(0f, 0f, _rotationOffset + Time.time * _rotationSpeed);
        }
    }
}