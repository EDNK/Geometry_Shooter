using Code.Scripts.Enemies;
using MyPooler;
using UnityEngine;

namespace Code.Scripts.Systems
{
    public class EnemySpawningSystem : IInitializableSystem, IExecutiveSystem
    {
        private readonly EnemiesVariantsHolder _enemiesVariantsHolder;
        private readonly AliveEnemies _aliveEnemies;
        private readonly Camera _camera;

        private float _spawningDelay = 2f;
        private int _firstPackSpawn = 10;
        private float _lastSpawnTime;

        public EnemySpawningSystem(EnemiesVariantsHolder enemiesVariantsHolder, AliveEnemies aliveEnemies)
        {
            _enemiesVariantsHolder = enemiesVariantsHolder;
            _aliveEnemies = aliveEnemies;
            _camera = Camera.main;
        }

        public void Initialize()
        {
            CreateEnemy(_firstPackSpawn);
        }

        public void Execute()
        {
            if (CanSpawn())
            {
                CreateEnemy();
            }
        }

        private void CreateEnemy(int n = 1)
        {
            _lastSpawnTime = Time.time;
            var enemiesLength = _enemiesVariantsHolder.Enemies.Length;

            for (var i = 0; i < n; i++)
            {
                var enemyToSpawn = _enemiesVariantsHolder.Enemies[Random.Range(0, enemiesLength)];
                var newPos = RandomPositionForEnemy();
                var enemy = ObjectPooler.Instance.GetFromPool(enemyToSpawn.name, newPos, Quaternion.identity).GetComponent<Enemy>();

                _aliveEnemies.AddEnemy(enemy);
            }
        }

        private Vector3 RandomPositionForEnemy()
        {
            var pixelWidth = _camera.pixelWidth;
            var x = Random.Range(0, pixelWidth);
            var pos = _camera.ScreenToWorldPoint(new Vector3(x, _camera.pixelHeight, 0))+Vector3.up;
            return pos;
        }

        private bool CanSpawn()
        {
            return Time.time - _lastSpawnTime >= _spawningDelay;
        }
    }
}