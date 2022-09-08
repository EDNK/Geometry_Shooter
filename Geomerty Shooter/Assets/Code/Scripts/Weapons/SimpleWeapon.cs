using System.Numerics;

namespace Code.Scripts.Weapons
{
    public class SimpleWeapon : IWeapon
    {
        private BigInteger _damage = 1;
        private float _shootCooldown = 0.05f;
        private int MaxBulletsAtShot = 5;
        private string BulletPrefabName = "SimpleBullet";

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