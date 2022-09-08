using System;
using UnityEngine;

namespace Code.Scripts.Weapons.Bullets
{
    public class Bullet : MonoBehaviour
    {
        public float Speed { private set; get; }
        private const float DefaultSpeed = 10f;

        private void Awake()
        {
            Speed = DefaultSpeed;
        }
    }
}