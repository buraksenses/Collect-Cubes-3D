using System.Collections.Generic;
using EZ_Pooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CollectCubes.Managers
{
    public class SpawnManager : Singleton<SpawnManager>
    {
        [SerializeField] private DataManager gameData;
        [SerializeField] private Transform cubePrefab;
        
        public List<Transform> spawnedCubes = new List<Transform>();//List of spawned cubes
        
        private int _minusEffectorX; 
        private int _minusEffectorZ; 
        
        private float _minSpawnPointX = 0f; //Minimum x value of spawn point
        private float _maxSpawnPointX = 3f; //Maximum x value of spawn point
        
        private float _minSpawnPointZ = 0f; //Minimum z value of spawn point
        private float _maxSpawnPointZ = 1f; //Minimum z value of spawn point
        
        private float _spawnSpeed = .05f;
        
        private void SpawnCubePrefab()
        {
            _spawnSpeed -= Time.deltaTime;
            
            if (spawnedCubes.Count >= gameData.maxCubesAtATime) return;
            if (_spawnSpeed > 0) return;

            _minusEffectorX = Random.Range(0, 100) >= 50 ? 1 : -1; //Randomize the spawn point's X axis value
            _minusEffectorZ = Random.Range(0, 100) >= 50 ? 1 : -1; //Randomize the spawn point's Z axis value
         
            var cube = EZ_PoolManager.Spawn(cubePrefab, 
                new Vector3(Random.Range(_minusEffectorX * _minSpawnPointX, _minusEffectorX * _maxSpawnPointX), cubePrefab.localScale.magnitude * .5f, 
                    Random.Range(_minusEffectorZ * _minSpawnPointZ, _minusEffectorZ * _maxSpawnPointZ)),Quaternion.identity);

            spawnedCubes.Add(cube);
            _spawnSpeed = .05f;
        }
        

        private void Start()
        {
            // ===== Event Assignments =====
            EventManager.onUpdate += SpawnCubePrefab;
        }
    }
}

