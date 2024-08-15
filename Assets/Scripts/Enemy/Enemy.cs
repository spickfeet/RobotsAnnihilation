using Assets.Scripts.Enemy.Weapons;
using Assets.Scripts.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int _health;
    [SerializeField] private GameObject _destroyEffectPrefab;
    [SerializeField] private GameObject[] _dropPrefabs;
    [SerializeField] private int _chanceDropMedicKit;
    [SerializeField] private AudioClip _applyDamageSound;

    private bool _haveTeleporter = false;

    private AudioSource _source;
    private Animator _animator;

    [SerializeField] private int _currentHealth;

    public Action OnHealthChanged;

    public bool HaveTeleporter
    {
        get { return _haveTeleporter; }
        set { _haveTeleporter = value; }
    }

    public int MaxHealth
    {
        get { return _health; }
        set { _health = value; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    public GameObject DestroyEffectPrefab
    {
        get { return _destroyEffectPrefab;}
        set { _destroyEffectPrefab = value; }
    }

    private void Awake()
    {
        _currentHealth = _health;
        _source = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _source.PlayOneShot(_applyDamageSound);
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Die();
        }
        OnHealthChanged?.Invoke();

        _animator.Play("EnemyBlink");
    }
    public void Die()
    {
        DropItem();
        Instantiate(_destroyEffectPrefab,transform.position,transform.rotation);
        Destroy(gameObject);
    }
    private void DropItem()
    {
        if(UnityEngine.Random.Range(0, 101) <= _chanceDropMedicKit)
        {
            if(_dropPrefabs[0] != null)
                Instantiate(_dropPrefabs[0],transform.position,transform.rotation);
        }
        if (_haveTeleporter == true)
        {
            if (_dropPrefabs[1] != null)
                Instantiate(_dropPrefabs[1], transform.position, transform.rotation);
        }
    }
}
