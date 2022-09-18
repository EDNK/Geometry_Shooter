using System;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class EnemyMoveSystem : IExecutiveSystem
    {
        private readonly AliveEnemies _aliveEnemies;

        public EnemyMoveSystem(AliveEnemies aliveEnemies)
        {
            _aliveEnemies = aliveEnemies;
        }

        public void Execute()
        {
            foreach (var enemy in _aliveEnemies.Enemies)
            {
                enemy.transform.position += enemy.FallingVector * Time.deltaTime;
            }
        }
    }
}
