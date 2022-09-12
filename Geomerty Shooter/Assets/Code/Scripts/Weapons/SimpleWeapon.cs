using System.Numerics;

namespace Code.Scripts.Weapons
{
    public class SimpleWeapon : IWeapon
    {
        private BigInteger _damage;
        private float _shootCooldown;
        private int MaxBulletsAtShot;
        private string BulletPrefabName;

        public SimpleWeapon()
        {
            _damage = 1;
            _shootCooldown = 0.7f;
            MaxBulletsAtShot = 5;
            BulletPrefabName = "SimpleBullet";
        }

        public BigInteger GetWeaponDamage()
        {
            return _damage;
        }

        public float GetShootCooldown()
        {
            return _shootCooldown;
        }

        public int GetMaxBulletsAtShot()
        {
            return MaxBulletsAtShot;
        }

        public string GetBulletPrefabName()
        {
            return BulletPrefabName;
        }
    }
}