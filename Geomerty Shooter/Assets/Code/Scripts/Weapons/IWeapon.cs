namespace Code.Scripts.Weapons
{
    public interface IWeapon
    {
        float GetShootCooldown();
        int GetMaxBulletsAtShot();
        IBullet GetBullet();
    }
}
