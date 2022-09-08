using System.Numerics;
using Code.Scripts.Weapons.Bullets;
using UnityEngine;

namespace Code.Scripts.Weapons
{
    public interface IWeapon
    {
        BigInteger GetWeaponDamage();
        float GetShootCooldown();
        int GetMaxBulletsAtShot();
        string GetBulletPrefabName();
    }
}