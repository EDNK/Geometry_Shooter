using System.Collections.Generic;
using System.Linq;
using Code.Scripts.Weapons.Bullets;
using MyPooler;
using UnityEngine;

namespace Code.Scripts.ShellObjects
{
    public class AliveBullets
    {
        private readonly Dictionary<int, Bullet> _dictionary;

        public AliveBullets()
        {
            _dictionary = new Dictionary<int, Bullet>(100);
        }

        public void AddBullets(IEnumerable<Bullet> bullets)
        {
            foreach (var bullet in bullets)
            {
                _dictionary.Add(bullet.gameObject.GetInstanceID(), bullet);
            }
        }

        public IEnumerable<Bullet> GetBullets()
        {
            return _dictionary.Values;
        }

        private void RemoveBullet(int key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                return;
            }

            var bullet = _dictionary[key];
            _dictionary.Remove(key);
            bullet.DiscardToPool();
        }

        public void RemoveBullets(IEnumerable<int> keys)
        {
            foreach (var key in keys.ToList())
            {
                RemoveBullet(key);
            }
        }
    }
}