using System.Collections.Generic;
using UnityEngine;

public class TeleporterSetter : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemySpawners;
    private void Update()
    {
        for (int i = 0; i < _enemySpawners.Count; i++)
        {
            if (_enemySpawners[i] == null)
            {
                _enemySpawners.Remove(_enemySpawners[i]);
                if (_enemySpawners.Count == 1)
                {
                    _enemySpawners[0].HaveTeleporter = true;
                }
                return;
            }
        }
        if (_enemySpawners.Count == 0)
        {
            Destroy(gameObject);
        }
    }
}
