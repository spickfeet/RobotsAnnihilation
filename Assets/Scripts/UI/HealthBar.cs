using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _healPointPrefab;
    [SerializeField] private Transform _healthBar;

    private List<GameObject> _healPoints;

    private void Awake()
    {
        _healPoints = new List<GameObject>();
        _player.OnHealthChanged += UpdateHealth;
    }

    private void Start()
    {
        for (int i = 0; i < _player.CurrentHealth; i++)
        {
            GameObject healPoint = Instantiate(_healPointPrefab);
            healPoint.transform.SetParent(_healthBar, false);
            _healPoints.Add(healPoint);
        }
    }

    private void UpdateHealth(int currentHealth)
    {
        foreach (var healPoint in _healPoints)
        {
            healPoint.SetActive(false);
        }
        for (int i = 0; i < currentHealth; i++)
        {
            _healPoints[i].SetActive(true);
        }
    }
}
