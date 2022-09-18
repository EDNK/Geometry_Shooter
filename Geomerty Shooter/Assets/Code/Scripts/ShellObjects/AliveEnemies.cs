using System.Collections.Generic;
using Code.Scripts.Enemies;

public class AliveEnemies
{
    public List<Enemy> Enemies { get; }

    public AliveEnemies()
    {
        Enemies = new List<Enemy>(20);
    }

    public void AddEnemies(IEnumerable<Enemy> enemies)
    {
        Enemies.AddRange(enemies);
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }
}