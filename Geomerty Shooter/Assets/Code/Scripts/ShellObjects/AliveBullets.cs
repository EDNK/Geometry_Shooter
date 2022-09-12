using System.Collections.Generic;
using Code.Scripts.Weapons.Bullets;

namespace Code.Scripts.ShellObjects
{
    public class AliveBullets
    {
        public List<Bullet> Bullets { get; private set; }

        public AliveBullets()
        {
            Bullets = new List<Bullet>(20);
        }

        public void AddBullets(IEnumerable<Bullet> bullets)
        {
            Bullets.AddRange(bullets);
        }
    }
}