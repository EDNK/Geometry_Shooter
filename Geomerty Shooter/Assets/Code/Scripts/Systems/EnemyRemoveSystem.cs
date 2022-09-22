using System.Collections.Generic;
using Code.Scripts.Enemies;
using Code.Scripts.Systems;

public class EnemyRemoveSystem : IExecutiveSystem
{
    private readonly List<Enemy> _aliveEnemies;

    public EnemyRemoveSystem(AliveEnemies aliveEnemies)
    {
        _aliveEnemies = aliveEnemies.Enemies;
    }

    public void Execute()
    {
        for (var i = _aliveEnemies.Count - 1; i >= 0; i--)
        {
            if (_aliveEnemies[i].HealthPoints > 0) continue;
            RemoveEnemy(i);
        }
    }

    private void RemoveEnemy(int i)
    {
        var enemy = _aliveEnemies[i];
        _aliveEnemies[i] = _aliveEnemies[_aliveEnemies.Count-1];
        _aliveEnemies.RemoveAt(_aliveEnemies.Count-1);
        enemy.DiscardToPool();
    }
}