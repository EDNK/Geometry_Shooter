using System;
using System.Collections.Generic;
using Code.Scripts.Weapons;
using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField] private Transform[] _spawnPoints;
        private IWeapon _weapon;

        private void Awake()
        {
            _weapon = new SimpleWeapon();
        }

        public IEnumerable<Transform> GetSuitableFirePosTransforms(int bulletsCount)
        {
            return _spawnPoints;
        }

        public float GetShootCooldown()
        {
            return _weapon.GetShootCooldown();
        }

        public void SetNewWeapon(IWeapon weapon)
        {
            _weapon = weapon;
        }

        public IWeapon GetWeapon()
        {
            return _weapon;
        }
    }
}