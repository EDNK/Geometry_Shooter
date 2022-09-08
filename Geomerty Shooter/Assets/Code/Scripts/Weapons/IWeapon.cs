using System.Numerics;
using Code.Scripts.Weapons.Bullets;

namespace Code.Scripts.Weapons
{
    public interface IWeapon
    {
        BigInteger GetWeaponDamage();
        float GetShootCooldown();
        int GetMaxBulletsAtShot();
        Bullet GetBullet();
    }
}
