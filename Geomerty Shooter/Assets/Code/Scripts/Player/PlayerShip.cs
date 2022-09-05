using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerShip : MonoBehaviour
    {
        private float _speed;
        // BULLET REF POINTS
        // WEAPON

        public float GetShootCooldown()
        {
            //TODO GET COOLDOWN FROM WEAPON
            return 5f;
        }

        public void GetWeapon()
        {
            return;
        }
    }
}
