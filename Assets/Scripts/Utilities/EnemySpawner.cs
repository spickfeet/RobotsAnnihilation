using Assets.Scripts.Enemy.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemiesPrefabs;
    [SerializeField] private float _spawnDistance;

    [SerializeField] private float _minSpawnTime;
    [SerializeField] private float _maxSpawnTime;

    [SerializeField] private float _spawnTimer;

    [SerializeField] private int _maxSpawnCount;

    [SerializeField] private List<GameObject> _enemies;

    private void Start()
    {
        _enemies = new List<GameObject>();
        _spawnTimer = Random.Range(_minSpawnTime, _maxSpawnTime);
    }

    private void Update()
    {

        for (int i = 0; i < _enemies.Count; i++)
        {
            if (_enemies[i] == null)
            {
                _enemies.Remove(_enemies[i]);
                return;
            }
        }
        if (_spawnTimer <= 0 && _enemies.Count < _maxSpawnCount)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-_spawnDistance, _spawnDistance) * 0.5f, 
                transform.position.y + Random.Range(-_spawnDistance, _spawnDistance) * 0.5f, transform.position.z);

            GameObject enemy = Instantiate(_enemiesPrefabs[Random.Range(0,2)], spawnPos, transform.rotation);
            _spawnTimer = Random.Range(_minSpawnTime, _maxSpawnTime);
            _enemies.Add(enemy);
        }
        else
        {
            _spawnTimer -= Time.deltaTime;
        }
    }
}
